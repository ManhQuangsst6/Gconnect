namespace Gconnect.Domain.Entities;
public partial class DmPhong : BaseAuditableEntity
{
    public string Id { get; set; } = null!;

    public string? TenPhong { get; set; }
}
