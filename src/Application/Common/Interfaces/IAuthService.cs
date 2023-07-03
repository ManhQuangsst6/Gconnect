using Gconnect.Application.Auth;

namespace Gconnect.Application.Common.Interfaces;
public interface IAuthService
{
    SignInResponse SignIn(SignInModel model);
    void SingOut(string username);
    string GetFullName(string username);
}
