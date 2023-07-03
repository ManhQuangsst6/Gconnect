namespace Gconnect.Application.Auth;
public class SignInResponse
{
    public string Id { get; set; }  
    public string UserName { get; set; }
    public string Fullname { get; set; }
    public string Permissions { get; set; }
    public string Token { get; set; }
    public string SSOToken { get; set; }
    public DateTime? ValidTo { get; set; }
    public bool IsSuccess { get; set; }
    public string ErrMessages { get; set; }
}
