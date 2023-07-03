using System;
using System.Collections.Generic;

namespace Gconnect.Domain.Entities;

public partial class AspNetUserClaim
{
    public string Id { get; set; }

    public string UserId { get; set; } = null!;

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual AspNetUser User { get; set; } = null!;
}
