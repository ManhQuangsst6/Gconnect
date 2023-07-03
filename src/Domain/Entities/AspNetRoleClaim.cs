using System;
using System.Collections.Generic;

namespace Gconnect.Domain.Entities;

public partial class AspNetRoleClaim
{
    public string Id { get; set; }

    public string RoleId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual AspNetRole Role { get; set; } = null!;
}
