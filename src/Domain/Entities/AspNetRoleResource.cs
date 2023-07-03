using System;
using System.Collections.Generic;

namespace Gconnect.Domain.Entities;

public partial class AspNetRoleResource
{
    public string Id { get; set; }

    public string ResouceId { get; set; }

    public string RoleId { get; set; } = null!;

    public virtual AspNetResource Resouce { get; set; } = null!;

    public virtual AspNetRole Role { get; set; } = null!;
}
