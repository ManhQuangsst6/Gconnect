using Gconnect.Domain.Entities;
using Gconnect.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gconnect.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;
    //private readonly UserManager<ApplicationUser> _userManager;
    //private readonly RoleManager<IdentityRole> _roleManager;

    //public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
    //    ApplicationDbContext context,
    //    UserManager<ApplicationUser> userManager,
    //    RoleManager<IdentityRole> roleManager)
    //{
    //    _logger = logger;
    //    _context = context;
    //    _userManager = userManager;
    //    _roleManager = roleManager;
    //}
    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
       ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
            if (_context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default roles
        //var administratorRole = new IdentityRole("Administrator");
        //var managerRole = new IdentityRole("Manager");
        //var publicRole = new IdentityRole("PublicRole");


        //if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        //{
        //    await _roleManager.CreateAsync(administratorRole);
        //}
        //if (_roleManager.Roles.All(r => r.Name != managerRole.Name))
        //{
        //    await _roleManager.CreateAsync(managerRole);
        //}
        //if (_roleManager.Roles.All(r => r.Name != publicRole.Name))
        //{
        //    await _roleManager.CreateAsync(publicRole);
        //}

        //// Default users
        //var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        //if (_userManager.Users.All(u => u.UserName != administrator.UserName))
        //{
        //    await _userManager.CreateAsync(administrator, "Administrator1!");
        //    await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name, managerRole.Name });
        //}

        var administratorRole = new AspNetRole();
        administratorRole.Id = Guid.NewGuid().ToString();
        administratorRole.Name = "Administrator";
        var managerRole = new AspNetRole();
        managerRole.Id = Guid.NewGuid().ToString();
        managerRole.Name = "User";
        var publicRole = new AspNetRole();
        publicRole.Id = Guid.NewGuid().ToString();
        publicRole.Name = "PublicRole";


        if (_context.AspNetRoles.All(r => r.Name != administratorRole.Name))
        {
            _context.AspNetRoles.Add(administratorRole);
        }
        if (_context.AspNetRoles.All(r => r.Name != managerRole.Name))
        {
            _context.AspNetRoles.Add(managerRole);
        }
        if (_context.AspNetRoles.All(r => r.Name != publicRole.Name))
        {
            _context.AspNetRoles.Add(publicRole);
        }
        await _context.SaveChangesAsync();

        // Default users
        var administrator = new AspNetUser {Id = Guid.NewGuid().ToString(), UserName = "administrator", Email = "administrator@localhost", PasswordHash = "Ab@123456" };

        if (_context.AspNetUsers.All(u => u.UserName != administrator.UserName))
        {
            _context.AspNetUsers.Add(administrator);
            await _context.SaveChangesAsync();
            administrator.AspNetUserRoles.Add(new AspNetUserRole() { RoleId = administratorRole.Id, UserId = administrator.Id });
            await _context.SaveChangesAsync();
        }
    }
}
