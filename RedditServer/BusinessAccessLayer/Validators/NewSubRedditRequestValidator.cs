using Common.Constants;
using Entities.DTOs.Request;
using FluentValidation;
using static Common.Constants.ValidationConstants;
namespace BusinessAccessLayer.Validators;
public class NewSubRedditRequestValidator : AbstractValidator<NewSubRedditRequestDto>
{
    public NewSubRedditRequestValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(model => model.Title)
            .NotNull().NotEmpty()
            .MinimumLength(MinSubRedditTitleLength)
            .MaximumLength(MaxSubRedditTitleLength);

        RuleFor(model => model.Slug)
            .NotNull().NotEmpty()
            .MinimumLength(MinSubRedditSlugLength)
            .MaximumLength(MaxSubRedditSlugLength)
            .Matches(SubRedditSlugRegEx)
                .WithMessage(MessageConstants.InvalidSubRedditSlug);

        RuleFor(model => model.Description)
            .NotNull().NotEmpty()
            .MinimumLength(MinSubRedditDescriptionLength)
            .MaximumLength(MaxSubRedditDescriptionLength);

        RuleFor(model => model.Icon)
            .SetValidator(new IconFileValidator());

        RuleFor(model => model.Banner)
            .SetValidator(new BannerFileValidator());

        RuleFor(model => model.Topics)
            .ForEach(topic => topic.Must(topic => topic > 0)
                                        .WithMessage(MessageConstants.InvalidRedditTopicId)
                    );

        RuleFor(model => model.Type)
            .NotEmpty()
            .IsInEnum()
                .WithMessage(MessageConstants.InvalidSubRedditType);
    }
}
