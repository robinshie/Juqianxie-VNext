﻿using FluentValidation;

namespace IdentityService.WebAPI.Controllers.Login;
public record LoginByHospitalNumberAndPwdRequest(string HospitalNumber ,string Password);
public class LoginByHospitalNumberAndPwdRequestValidator : AbstractValidator<LoginByHospitalNumberAndPwdRequest>
{
    public LoginByHospitalNumberAndPwdRequestValidator()
    {
        RuleFor(e => e.HospitalNumber).NotNull().NotEmpty();
        RuleFor(e => e.Password).NotNull().NotEmpty();
    }
}
public record LoginByShowIDAndPwdRequest(long ID, string Password);
public class LoginByShowIDAndPwdRequestValidator : AbstractValidator<LoginByShowIDAndPwdRequest>
{
    public LoginByShowIDAndPwdRequestValidator()
    {
        RuleFor(e => e.ID).NotNull();
        RuleFor(e => e.Password).NotNull().NotEmpty();
    }
}