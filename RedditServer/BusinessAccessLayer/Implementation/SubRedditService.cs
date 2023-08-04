using BusinessAccessLayer.Abstraction;
using BusinessAccessLayer.AppUser;
using Common.Constants;
using Common.Exceptions;
using DataAccessLayer.Abstraction;
using DataAccessLayer.Criteria;
using Entities.DataModels;
using Entities.DTOs.Request;
using Entities.DTOs.Response;
using Entities.Mapper;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace BusinessAccessLayer.Implementation;

public class SubRedditService : ISubRedditService
{
    #region Properties

    private readonly ISubRedditRepository _subRedditRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFirebaseStorageService _firebaseStorageService;
    private readonly ISubRedditTopicService _subRedditTopicService;
    private readonly IApplicationUser _appUser;
    private readonly ISubRedditModeratorService _subRedditModeratorService;

    #endregion Properties

    #region Constructors

    public SubRedditService(ISubRedditRepository subRedditRepository,
        IUnitOfWork unitOfWork,
        IFirebaseStorageService firebaseStorageService,
        ISubRedditTopicService subRedditTopicService,
        IApplicationUser appUser,
        ISubRedditModeratorService subRedditModeratorService)
    {
        _subRedditRepository = subRedditRepository;
        _unitOfWork = unitOfWork;
        _firebaseStorageService = firebaseStorageService;
        _subRedditTopicService = subRedditTopicService;
        _appUser = appUser;
        _subRedditModeratorService = subRedditModeratorService;
    }

    #endregion Constructors

    #region Interface Methods

    public async Task<string> CreateAsync(NewSubRedditRequestDto dto,
        CancellationToken cancellationToken = default)
    {
        SubReddit model = dto.ToSubReddit();
        model.CreatedById = _appUser.GetUserId()!.Value;

        using IDbContextTransaction transcation = await _unitOfWork.BeginTransactionAsync();
        try
        {
            await SetSubRedditIconAndBanner(dto, model, cancellationToken);

            await _subRedditRepository.AddAsync(model, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            await _subRedditTopicService.AddAsync(model.Id, dto.Topics, cancellationToken);
            await _subRedditModeratorService.AddAsync(model.Id, model.CreatedById);

            await _unitOfWork.SaveAsync(cancellationToken);
            await transcation.CommitAsync(cancellationToken);

            return model.Slug;
        }
        catch
        {
            await transcation.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<SubRedditProfileResponseDto> GetAsync(string slug,
        CancellationToken cancellationToken)
    {
        FilterCriteria<SubReddit> criteria = GetSubRedditProfileCriteria(slug);

        SubReddit? model = await _subRedditRepository.FirstOrDefaultAsync(criteria, cancellationToken);

        if (model is null)
            throw new ResourceNotFoundException(MessageConstants.SUBREDDIT_NOT_FOUND.Replace("#", slug));

        return model.ToSubRedditProfileResponseDto();
    }

    #endregion Interface Methods

    #region Helper Methods

    private async Task<string?[]> UploadSubredditBannerAndIcon(NewSubRedditRequestDto dto,
        CancellationToken cancellationToken)
    {
        string? iconUrl = await _firebaseStorageService.UploadFile(dto.Icon, SystemConstants.FirebaseSubRedditIconFolder, cancellationToken);
        string? bannerUrl = await _firebaseStorageService.UploadFile(dto.Banner, SystemConstants.FirebaseSubRedditBannerFolder, cancellationToken);

        return new string?[] { iconUrl, bannerUrl };
    }

    private async Task SetSubRedditIconAndBanner(NewSubRedditRequestDto dto, SubReddit model,
        CancellationToken cancellationToken)
    {
        string?[] media = await UploadSubredditBannerAndIcon(dto, cancellationToken);

        model.Icon = media[0]!;
        model.Banner = media[1]!;
    }

    private static FilterCriteria<SubReddit> GetSubRedditProfileCriteria(string slug)
    {
        FilterCriteria<SubReddit> criteria = new();

        criteria.Filter = GetBySlugFilter(slug);
        criteria.Select = SubRedditProfileSelect();

        return criteria;
    }
    #endregion Helper Methods

    #region Helper Filters
    private static Expression<Func<SubReddit, SubReddit>> SubRedditProfileSelect()
        => model => new SubReddit()
        {
            Id = model.Id,
            Title = model.Title,
            CreatedOn = model.CreatedOn,
            Slug = model.Slug,
            Description = model.Description,
            MemberCount = model.MemberCount,
            CreatedBy = model.CreatedBy.ToUserProfilePeek(),
            Icon = model.Icon,
            Banner = model.Banner,
            Type = model.Type,
            Status = model.Status,
            Topics = model.Topics.Select
            (
                topic => new SubRedditTopic()
                {
                    SubRedditId = topic.SubRedditId,
                    TopicId = topic.TopicId,
                    Topic = topic.Topic
                }
            ).ToList(),
            Moderators = model.Moderators.Select
            (
                mode => new SubRedditModerator()
                {
                    UserId = mode.UserId,
                    SubRedditId = mode.SubRedditId,
                    User = mode.User.ToUserProfilePeek(),
                }
            ).ToList(),
        };

    public static Expression<Func<SubReddit, bool>> GetBySlugFilter(string slug) =>
        model => model.Slug.Equals(slug);

    #endregion
}