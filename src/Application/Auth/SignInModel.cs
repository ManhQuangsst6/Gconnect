namespace Gconnect.Application.Auth;
public class SignInModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public bool IsSSO { get; set; }
    public string SSOToken { get; set; }
}
public class SSOModel
{
    public string Code { get; set; } = string.Empty;
    public bool IsLocal { get; set; } = false;
    public string RedirectUri { get; set; }
}
public class TokenClaim
{
    public string access_token { get; set; } = string.Empty;
    public string refresh_token { get; set; } = string.Empty;
    public string scope { get; set; } = string.Empty;
    public string id_token { get; set; } = string.Empty;
    public string token_type { get; set; } = string.Empty;
    public int expires_in { get; set; } = 0;
}
