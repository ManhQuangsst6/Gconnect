using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Gconnect.Application.Auth;
using Gconnect.Application.Common.Interfaces;
using Gconnect.Domain.Common;
using Gconnect.Domain.Entities;

namespace Gconnect.Infrastructure.Authenticate;
public class AuthService : IAuthService
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IApplicationDbContext _context;
    public AuthService(IJwtTokenService jwtTokenService, IApplicationDbContext context)
    {
        _jwtTokenService = jwtTokenService;
        _context = context;
    }
    public SignInResponse SignIn(SignInModel model)
    {
        SignInResponse result = new SignInResponse();
        result.IsSuccess = _context.AspNetUsers.FirstOrDefault(c => c.UserName == model.UserName) != null;
        if (result.IsSuccess || model.IsSSO == true)
        {
            if (model.IsSSO == true && !result.IsSuccess)
            {
                var userCreate = new AspNetUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    Email = model.UserName,
                };
                _context.AspNetUsers.Add(userCreate);
                _context.SaveChangesAsync(new CancellationToken());

            }
            var user = _context.AspNetUsers.First(c => c.UserName == model.UserName);
            JwtSecurityToken token = GenerateJwtToken(user.UserName);
            result.Id = user.Id;
            result.UserName = user.UserName;
            result.Fullname = user.UserName;
            result.ValidTo = token.ValidTo;
            // Fake perrmission
            //List<string> staticconstList = new List<string>();
            //Type type = typeof(Permission);
            //foreach (var field in type.GetFields())
            //{
            //    var val = field.GetValue(null);
            //    staticconstList.Add(val.ToString());
            //}
            //result.Permissions = string.Join(",", staticconstList);
            // End fake Permission
            result.Token = new JwtSecurityTokenHandler().WriteToken(token);
            result.SSOToken = model.SSOToken;
        }

        return result;
    }
    private JwtSecurityToken GenerateJwtToken(string username)
    {
        var user = _context.AspNetUsers.First(c => c.UserName == username);
        var roleOfUser = _context.AspNetUserRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
        var roles = new List<AspNetRole>();
        roles.AddRange(_context.AspNetRoles.Where(c => roleOfUser.Contains(c.Id)).ToList());
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                //new Claim(Permission.Permissions, Permission.DmHuyen),
                //new Claim(Permission.Permissions, Permission.DmTinh),
                //new Claim(Permission.Permissions, Permission.DmXa),

            };

        // get user claim
        //notImplement

        // get role claim        
        var resouces = (from a in _context.AspNetUsers
                        join b in _context.AspNetUserRoles on a.Id equals b.UserId
                        join c in _context.AspNetRoles on b.RoleId equals c.Id
                        join d in _context.AspNetRoleResources on c.Id equals d.RoleId
                        join e in _context.AspNetResources on d.ResouceId equals e.Id
                        where a.Id == user.Id
                        select e.ResourceCode).ToList();

        foreach (var res in resouces)
        {

            claims.Add(new Claim(Permission.Permissions, res));
            //var role = _roleManager.FindByNameAsync(roleName).Result;
            //roleClaims.AddRange(_roleManager.GetClaimsAsync(role).Result);
        }

        // merge claim
        //claims.AddRange(userClaim);
        // claims.AddRange(roleClaims);

        // generate token
        var token = _jwtTokenService.GetJwtToken(claims);
        return token;
    }

    public void SingOut(string username)
    {

    }

    public string GetFullName(string username)
    {
        return string.Empty;
    }


}
