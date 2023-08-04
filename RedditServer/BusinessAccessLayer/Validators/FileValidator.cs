using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BusinessAccessLayer.Validators;
public class ImageFileValidator : AbstractValidator<IFormFile>
{
    public ImageFileValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;

        RuleFor(model => model.ContentType)
            .Must(model => model.Equals("image/jpeg") || model.Equals("image/jpg") || model.Equals("image/png"));
    }
}
