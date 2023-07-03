using System;
using System.Collections.Generic;

namespace Gconnect.Domain.Entities;

public partial class AspNetUserRole
{
    public string Id { get; set; }
    public string UserId { get; set; } = null!;

    public string RoleId { get; set; } = null!;


    public virtual AspNetRole Role { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
