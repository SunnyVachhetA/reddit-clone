using Common.Constants;
using Common.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BusinessAccessLayer.Validators;
public class IconFileValidator : AbstractValidator<IFormFile>
{
    public IconFileValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(model => model)
            .SetValidator(new ImageFileValidator())
                .WithMessage(MessageConstants.InvalidIconImageFile)
            .Must(model => model.Length < MemorySizeUtil.GetSizeInMB(SystemConstants.MaxIconSizeInMB))
                .WithMessage(MessageConstants.MaxSubRedditIconSizeLength);
    }
}
