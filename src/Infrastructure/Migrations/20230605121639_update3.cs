using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gconnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DonViId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TT_YeuCauLapDanhMucHoSo_DsDonVi_DonViId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                column: "DonViId");

            migrationBuilder.AddForeignKey(
                name: "FK_TT_YeuCauLapDanhMucHoSo_DsDonVi_DmDonVi_DonViId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                column: "DonViId",
                principalTable: "DmDonVi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TT_YeuCauLapDanhMucHoSo_DsDonVi_DmDonVi_DonViId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi");

            migrationBuilder.DropIndex(
                name: "IX_TT_YeuCauLapDanhMucHoSo_DsDonVi_DonViId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi");

            migrationBuilder.AlterColumn<string>(
                name: "DonViId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
