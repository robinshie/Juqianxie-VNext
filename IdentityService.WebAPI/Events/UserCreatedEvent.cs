namespace IdentityService.WebAPI.Events
{
    public record UserCreatedEvent(long Id, string UserName, string Password, string PhoneNum);
}
