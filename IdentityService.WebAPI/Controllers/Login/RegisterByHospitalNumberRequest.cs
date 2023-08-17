using FluentValidation;

namespace IdentityService.WebAPI.Controllers.Login
{
    public record RegisterByHospitalNumberRequest(string HospitalNumber, string UserName,string Password);
    public class RegisterByHospitalNumberRequestValidator : AbstractValidator<RegisterByHospitalNumberRequest>
    {
        public RegisterByHospitalNumberRequestValidator()
        {
            RuleFor(x => x.HospitalNumber).NotNull().NotEmpty();
            RuleFor(e => e.UserName).NotNull().NotEmpty();
            RuleFor(e => e.Password).NotNull().MinimumLength(6);
        }
    }
}
