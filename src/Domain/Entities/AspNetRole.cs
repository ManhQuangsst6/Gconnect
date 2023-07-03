using System;
using System.Collections.Generic;

namespace Gconnect.Domain.Entities;

public partial class AspNetRole
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; } = new List<AspNetRoleClaim>();

    public virtual ICollection<AspNetRoleResource> AspNetRoleResources { get; } = new List<AspNetRoleResource>();

    public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; } = new List<AspNetUserRole>();
}
