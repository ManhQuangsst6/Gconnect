using System;
using System.Collections.Generic;

namespace Gconnect.Domain.Entities;

public partial class AspNetResource
{
    public string Id { get; set; }

    public string ResourceCode { get; set; } = null!;

    public string? ResourceName { get; set; }

    public virtual ICollection<AspNetRoleResource> AspNetRoleResources { get; } = new List<AspNetRoleResource>();
}
