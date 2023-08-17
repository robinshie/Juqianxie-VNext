namespace IdentityService.WebAPI.Events
{
    public record ResetPasswordEvent(long Id, string UserName, string Password, string PhoneNum);
}
