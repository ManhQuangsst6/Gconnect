using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gconnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TT_DanhMucHoSoChiTiet_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoChiTiet");

            migrationBuilder.DropForeignKey(
                name: "FK_TT_DanhMucHoSoDuKien_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoDuKien");

            migrationBuilder.AddForeignKey(
                name: "FK_TT_DanhMucHoSoChiTiet_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoChiTiet",
                column: "YeuCauLapDanhMucHoSoId",
                principalTable: "TT_YeuCauLapDanhMucHoSo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TT_DanhMucHoSoDuKien_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoDuKien",
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

            migrationBuilder.DropForeignKey(
                name: "FK_TT_DanhMucHoSoDuKien_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoDuKien");

            migrationBuilder.AddForeignKey(
                name: "FK_TT_DanhMucHoSoChiTiet_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoChiTiet",
                column: "YeuCauLapDanhMucHoSoId",
                principalTable: "TT_YeuCauLapDanhMucHoSo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TT_DanhMucHoSoDuKien_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoDuKien",
                column: "YeuCauLapDanhMucHoSoId",
                principalTable: "TT_YeuCauLapDanhMucHoSo",
                principalColumn: "Id");
        }
    }
}
