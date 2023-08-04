using Common.Constants;
using Common.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BusinessAccessLayer.Validators;
public class BannerFileValidator : AbstractValidator<IFormFile>
{
    public BannerFileValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(model => model)
            .SetValidator(new ImageFileValidator())
                .WithMessage(MessageConstants.InvalidBannerImageFile)
            .Must(model => model.Length < MemorySizeUtil.GetSizeInMB(SystemConstants.MaxBannerSizeInMB))
                .WithMessage(MessageConstants.MaxSubRedditBannerSizeLength);
    }

}
