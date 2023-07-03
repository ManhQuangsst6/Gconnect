using Microsoft.AspNetCore.Identity;

namespace Gconnect.Infrastructure.Identity;
public class ApplicationRole : IdentityRole
{
    public ApplicationRole(String name)
    {
        Name = name;   
    }
}
