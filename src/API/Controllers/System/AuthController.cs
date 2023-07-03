using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using Gconnect.API.Common;
using Gconnect.Application.Auth;
using Gconnect.Application.Common.Interfaces;
//using Gconnect.Application.NhatKyHeThongs.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace Gconnect.API.Controllers.System;
[Route("api/[controller]/[action]")]
public class AuthController : ApiControllerBase
{
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;
    public AuthController(IAuthService authService, IConfiguration configuration)
    {
        _authService = authService;
        _configuration = configuration;
    }

    public SignInResponse SignIn(SignInModel model)
    {
        SignInResponse result = _authService.SignIn(model);
        //CreateNhatKyHeThongCommand command = new CreateNhatKyHeThongCommand();
        //command.TenNguoiDung = result.UserName;
        //command.HanhDong = "Đăng nhập";
        //command.NoiDung = "Login into system";
        //command.Module = "Hệ thống";
        //Mediator.Send(command);
        if (!result.IsSuccess)
        {
            result.ErrMessages = "Username or password is not matched!";
        }
        return result;
    }
    [HttpPost]
    public async Task<SignInResponse> LoginSSO(SSOModel model)
    {
        var Secret = _configuration.GetValue<string>("SSO:" + (model.IsLocal ? "Local" : "Sever") + "_Secret");
        var ClientId = _configuration.GetValue<string>("SSO:" + (model.IsLocal ? "Local" : "Sever") + "_ClientId");
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri("https://dangnhap.moet.gov.vn");
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Content-Type", "application/x-www-form-urlencoded"),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", model.Code),
                new KeyValuePair<string, string>("redirect_uri", model.RedirectUri),
                new KeyValuePair<string, string>("client_id", ClientId),
                new KeyValuePair<string, string>("client_secret", Secret),
            });
            var result = client.PostAsync("/oauth2/token", content).Result;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                string resultContent = await result.Content.ReadAsStringAsync();
                var tokenObj = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenClaim>(resultContent);
                if (tokenObj != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jwtSecurityToken = handler.ReadJwtToken(tokenObj.id_token);
                    if (jwtSecurityToken != null)
                    {
                        var sub = jwtSecurityToken.Claims.FirstOrDefault(x => x.Type == "sub").Value;
                        if (sub != null)
                        {
                            SignInModel modelSignIn = new SignInModel();
                            modelSignIn.UserName = sub;
                            modelSignIn.Password = _configuration.GetValue<string>("SSO:Default_Password");
                            modelSignIn.IsSSO = true;
                            modelSignIn.SSOToken = tokenObj.id_token;
                            return SignIn(modelSignIn);
                        }
                    }
                }
            }
        }
        return new SignInResponse();
    }
}
