namespace Gconnect.Domain.Entities;
/// <summary>
/// Chi tiết các tài liệu trong danh mục hồ sơ cần lập
/// </summary>
public partial class TT_DanhMucHoSoChiTiet : BaseAuditableEntity
{
    public string DanhMucHoSoDuKienId { get; set; }
    public string? DonViId { get; set; }
    public string? YeuCauLapDanhMucHoSoId { get; set; }
    public string? PhongId { get; set; }
    public string? TenPhong { get; set; }
    public string? DonViLapDanhMucId { get; set; }
    public string? TenDonViLapDanhMuc { get; set; }
    public string? MatHoatDongId { get; set; }
    public string? TenMatHoatDong { get; set; }
    public string? SoKyHieu { get; set; }
    public string? TieuDe { get; set; }
    public string? ThoiHanBaoQuanId { get; set; }
    public string? TenThoiHanBaoQuan { get; set; }
    public string? NguoiLapId { get; set; }
    /// <summary>
    /// 0 - Vừa tạo
    /// 1 - Đang tổng hợp
    /// 2 - Đã Tổng hợp
    /// 3 - Đã Duyệt
    /// </summary>
    public int? TrangThai { get; set; }
    public TT_DanhMucHoSoDuKien DanhMucHoSoDuKien { get; set; }
    public TT_YeuCauLapDanhMucHoSo YeuCauLapDanhMucHoSo { get; set; }
}
