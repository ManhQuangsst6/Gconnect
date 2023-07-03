namespace Gconnect.Domain.Entities;
public partial class DmThoiHanBaoQuan : BaseAuditableEntity
{
    public string? TenThoiHanBaoQuan { get; set; }
    public int? ThoiGianBaoQuan { get; set; }
}
