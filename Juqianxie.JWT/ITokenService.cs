using System.Collections.Generic;
using System.Security.Claims;

namespace Juqianxie.JWT
{
    public interface ITokenService
    {
        string BuildToken(IEnumerable<Claim> claims, JWTOptions options);
    }
}
