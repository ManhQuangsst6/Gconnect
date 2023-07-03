namespace Gconnect.Domain.Entities;
public partial class DmDonVi : BaseAuditableEntity
{
    public string? MaDonVi { get; set; }
    public string? TenDonVi { get; set; }
    public string? IdDonViCha { get; set; } 
    public string? MaDonViCha { get; set; }

    public virtual ICollection<DmDonVi> DonViTrucThuocs { get; } = new List<DmDonVi>();
    public virtual DmDonVi? DonViCha { get; set; }
    public virtual ICollection<TT_YeuCauLapDanhMucHoSoDsDonVi> YeuCauLapHoSoCuaDonVi { get; } = new List<TT_YeuCauLapDanhMucHoSoDsDonVi>();
}
