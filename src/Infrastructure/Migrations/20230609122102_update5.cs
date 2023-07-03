using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gconnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DonViId",
                table: "TT_DanhMucHoSoChiTiet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenMatHoatDong",
                table: "TT_DanhMucHoSoChiTiet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenPhong",
                table: "TT_DanhMucHoSoChiTiet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenThoiHanBaoQuan",
                table: "TT_DanhMucHoSoChiTiet",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThai",
                table: "TT_DanhMucHoSoChiTiet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoChiTiet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TT_DanhMucHoSoChiTiet_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoChiTiet",
                column: "YeuCauLapDanhMucHoSoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TT_DanhMucHoSoChiTiet_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoChiTiet",
                column: "YeuCauLapDanhMucHoSoId",
                principalTable: "TT_YeuCauLapDanhMucHoSo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TT_DanhMucHoSoChiTiet_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoChiTiet");

            migrationBuilder.DropIndex(
                name: "IX_TT_DanhMucHoSoChiTiet_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoChiTiet");

            migrationBuilder.DropColumn(
                name: "DonViId",
                table: "TT_DanhMucHoSoChiTiet");

            migrationBuilder.DropColumn(
                name: "TenMatHoatDong",
                table: "TT_DanhMucHoSoChiTiet");

            migrationBuilder.DropColumn(
                name: "TenPhong",
                table: "TT_DanhMucHoSoChiTiet");

            migrationBuilder.DropColumn(
                name: "TenThoiHanBaoQuan",
                table: "TT_DanhMucHoSoChiTiet");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "TT_DanhMucHoSoChiTiet");

            migrationBuilder.DropColumn(
                name: "YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoChiTiet");
        }
    }
}
