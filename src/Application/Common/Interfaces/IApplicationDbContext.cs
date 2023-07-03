using Gconnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Gconnect.Application.Common.Interfaces;

public interface IApplicationDbContext
{

    public DbSet<AspNetResource> AspNetResources { get; }

    public DbSet<AspNetRole> AspNetRoles { get; }

    public DbSet<AspNetRoleClaim> AspNetRoleClaims { get; }

    public DbSet<AspNetRoleResource> AspNetRoleResources { get; }

    public DbSet<AspNetUser> AspNetUsers { get; }

    public DbSet<AspNetUserClaim> AspNetUserClaims { get; }

    public DbSet<AspNetUserLogin> AspNetUserLogins { get; }

    public DbSet<AspNetUserRole> AspNetUserRoles { get; }

    public DbSet<AspNetUserToken> AspNetUserTokens { get; }
    public DbSet<DmPhong> DmPhongs { get; }

    public DatabaseFacade Database { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
