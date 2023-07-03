namespace Gconnect.Domain.Entities;
/// <summary>
/// các đơn vị nhận yêu cầu lập danh mục hồ sơ
/// </summary>
public partial class TT_YeuCauLapDanhMucHoSoDsDonVi : BaseAuditableEntity
{
    public string YeuCauId { get; set; }
    public string DonViId { get; set; }
    public int? TinhTrang { get; set; }

    public virtual TT_YeuCauLapDanhMucHoSo YeuCauLapDanhMucHoSo { get; set; }
    public virtual DmDonVi DonViNhanYeuCau { get; set; }
}
