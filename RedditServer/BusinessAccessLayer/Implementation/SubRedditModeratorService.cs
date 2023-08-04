using BusinessAccessLayer.Abstraction;
using DataAccessLayer.Abstraction;
using Entities.DataModels;

namespace BusinessAccessLayer.Implementation;

public class SubRedditModeratorService : ISubRedditModeratorService
{
    #region Properties

    private readonly ISubRedditModeratorRepository _subRedditModeratorRepository;

    #endregion Properties

    #region Constructors

    public SubRedditModeratorService(ISubRedditModeratorRepository subRedditModeratorRepository)
    {
        _subRedditModeratorRepository = subRedditModeratorRepository;
    }

    #endregion Constructors

    #region Interface Methods

    public async Task AddAsync(Guid subRedditId, Guid userId)
    {
        SubRedditModerator model = new()
        {
            UserId = userId,
            SubRedditId = subRedditId,
        };
        await _subRedditModeratorRepository.AddAsync(model);
    }

    #endregion Interface Methods
}