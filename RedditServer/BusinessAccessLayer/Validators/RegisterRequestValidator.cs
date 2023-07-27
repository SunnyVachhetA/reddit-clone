using BusinessAccessLayer.Abstraction;
using Common.Constants;
using Entities.DTOs.Request;
using FluentValidation;
using static Common.Constants.ValidationConstants;
namespace BusinessAccessLayer.Validators;
public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
{
    private readonly IAccountService _accountService;
    public RegisterRequestValidator(IAccountService accountService)
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        _accountService = accountService;

        RuleFor(model => model.Username)
            .NotNull().NotEmpty()
            .MinimumLength(MinUsernameLength)
            .MaximumLength(MaxUsernameLength)
            .Matches(UsernameRegEx)
                .WithMessage(MessageConstants.UsernameRegExFailed)
            .Must(IsDuplicateUsername)
                .WithMessage(MessageConstants.UsernameAlreadyExists);

        RuleFor(model => model.Email)
          .NotNull().NotEmpty()
          .MinimumLength(MinEmailLength)
          .MaximumLength(MaxEmailLength)
          .Matches(EmailRegEx)
            .WithMessage(MessageConstants.EmailRegExFailed)
          .Must(IsDuplicateEmail)
            .WithMessage(MessageConstants.EmailAlreadyExists);

        RuleFor(model => model.Password)
          .NotNull().NotEmpty()
          .MinimumLength(MinPasswordLength)
          .MaximumLength(MaxPasswordLength)
          .Matches(PasswordRegEx)
            .WithMessage(MessageConstants.PasswordRegExFailed);
    }

    private bool IsDuplicateEmail(string email)
        => !(_accountService.IsDuplicateEmail(email).Result);

    private bool IsDuplicateUsername(string username)
        => !(_accountService.IsDuplicateUsername(username).Result);
}
