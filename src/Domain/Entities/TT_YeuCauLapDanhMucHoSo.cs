namespace Gconnect.Domain.Entities;
/// <summary>
/// Yêu cầu lập danh mục hồ sơ
/// </summary>
public partial class TT_YeuCauLapDanhMucHoSo: BaseAuditableEntity
{
    public string? TenYeuCau { get; set; }
    public int? Nam { get; set; }
    public string? GhiChu { get; set; }
    public int? TrangThai { get; set; }
    public int? TinhTrangPheDuyet { get; set; }

    public ICollection<TT_YeuCauLapDanhMucHoSoDsDonVi> DonViNhanYeuCaus { get; } = new List<TT_YeuCauLapDanhMucHoSoDsDonVi>();
    public ICollection<TT_DanhMucHoSoChiTiet> DanhMucHoSoChiTiets { get; } = new List<TT_DanhMucHoSoChiTiet>();
    public ICollection<TT_DanhMucHoSoDuKien> DanhMucHoSoDuKiens { get; } = new List<TT_DanhMucHoSoDuKien>();

}
