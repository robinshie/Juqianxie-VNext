
namespace IdentityService.WebAPI.Controllers.Login;
public record UserResponse(long Id, string PhoneNumber, DateTime CreationTime);
public record LoginResponse(string token, string ex);
public record LoginlongResponse(string token, long ex);