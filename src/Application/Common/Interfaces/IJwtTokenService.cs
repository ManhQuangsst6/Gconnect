using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Gconnect.Application.Common.Interfaces;
public interface IJwtTokenService
{
    JwtSecurityToken GetJwtToken(List<Claim> userClaims);
}