namespace Gconnect.Domain.Entities;
public class TT_KeHoachGiaoNop : BaseAuditableEntity
{
    public string? TenKeHoach { get; set; }
    public int? Nam { get; set; }
    public string? NguoiLap { get; set; }
    public string? GhiChu { get; set; }
    public int TrangThai { get; set; }
    public int? TinhTrangPheDuyet { get; set; }
    public ICollection<TT_KeHoachGiaoNopDonVi> KeHoachGiaoNopDonVis = new List<TT_KeHoachGiaoNopDonVi>();
}
