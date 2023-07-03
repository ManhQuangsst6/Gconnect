namespace Gconnect.Domain.Entities;
/// <summary>
/// Danh mục hồ sơ dự kiến của đơn vị
/// </summary>
public partial class TT_DanhMucHoSoDuKien : BaseAuditableEntity
{
    public int? Nam { get; set; }
    public string? SoQdPheDuyet { get; set; }
    public DateTime? NgayQdPheDuyet { get; set; }
    public string? GhiChu { get; set; }
    public string? DonViId { get; set; }
    public string? YeuCauLapDanhMucHoSoId { get; set; }
    public ICollection<TT_DanhMucHoSoChiTiet> DanhMucHoSoChiTiets { get; } = new List<TT_DanhMucHoSoChiTiet>();
    public TT_YeuCauLapDanhMucHoSo YeuCauLapDanhMucHoSo { get; set; }
}
