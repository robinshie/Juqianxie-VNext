using FluentValidation;

namespace IdentityService.WebAPI.Controllers.Login;
public record ChangeMyPasswordRequest(long id ,string Password, string Password2);
public class ChangePasswordRequestValidator : AbstractValidator<ChangeMyPasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(e => e.Password).NotNull().NotEmpty()
            .NotEqual(e => e.Password2);
        RuleFor(e => e.Password2).NotNull().NotEmpty();
    }
}
