namespace IdentityService.Domain
{
    public record UserCreatedEvent(long Id, string UserName, string Password, string PhoneNum);
}
