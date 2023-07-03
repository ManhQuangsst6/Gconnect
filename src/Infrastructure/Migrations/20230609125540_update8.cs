using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gconnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoDuKien",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TT_DanhMucHoSoDuKien_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoDuKien",
                column: "YeuCauLapDanhMucHoSoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TT_DanhMucHoSoDuKien_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoDuKien",
                column: "YeuCauLapDanhMucHoSoId",
                principalTable: "TT_YeuCauLapDanhMucHoSo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TT_DanhMucHoSoDuKien_TT_YeuCauLapDanhMucHoSo_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoDuKien");

            migrationBuilder.DropIndex(
                name: "IX_TT_DanhMucHoSoDuKien_YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoDuKien");

            migrationBuilder.AlterColumn<string>(
                name: "YeuCauLapDanhMucHoSoId",
                table: "TT_DanhMucHoSoDuKien",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
