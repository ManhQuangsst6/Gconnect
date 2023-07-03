
namespace Gconnect.Domain.Entities;
public class TT_KeHoachGiaoNopDonVi : BaseAuditableEntity
{
    public string? KeHoachGiaoNopId { get; set; }
    public string? DonViId { get; set; }
    public string? TenDonVi { get; set; }
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }
    public TT_KeHoachGiaoNop? KeHoachGiaoNop { get; set; }

}
