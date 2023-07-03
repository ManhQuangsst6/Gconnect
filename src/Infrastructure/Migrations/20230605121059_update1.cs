using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gconnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonVis_DonVis_DonViChaId",
                table: "DonVis");

            migrationBuilder.DropForeignKey(
                name: "FK_TtYeuCauLapDanhMucHoSoDsDonVis_TtYeuCauLapDanhMucHoSos_YeuCauLapDanhMucHoSoId",
                table: "TtYeuCauLapDanhMucHoSoDsDonVis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TtYeuCauLapDanhMucHoSos",
                table: "TtYeuCauLapDanhMucHoSos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TtYeuCauLapDanhMucHoSoDsDonVis",
                table: "TtYeuCauLapDanhMucHoSoDsDonVis");

            migrationBuilder.DropIndex(
                name: "IX_TtYeuCauLapDanhMucHoSoDsDonVis_YeuCauLapDanhMucHoSoId",
                table: "TtYeuCauLapDanhMucHoSoDsDonVis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DonVis",
                table: "DonVis");

            migrationBuilder.DropIndex(
                name: "IX_DonVis_DonViChaId",
                table: "DonVis");

            migrationBuilder.DropColumn(
                name: "YeuCauLapDanhMucHoSoId",
                table: "TtYeuCauLapDanhMucHoSoDsDonVis");

            migrationBuilder.DropColumn(
                name: "DonViChaId",
                table: "DonVis");

            migrationBuilder.RenameTable(
                name: "TtYeuCauLapDanhMucHoSos",
                newName: "TT_YeuCauLapDanhMucHoSo");

            migrationBuilder.RenameTable(
                name: "TtYeuCauLapDanhMucHoSoDsDonVis",
                newName: "TT_YeuCauLapDanhMucHoSo_DsDonVi");

            migrationBuilder.RenameTable(
                name: "DonVis",
                newName: "DmDonVi");

            migrationBuilder.AlterColumn<string>(
                name: "YeuCauId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaDonViCha",
                table: "DmDonVi",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaDonVi",
                table: "DmDonVi",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdDonViCha",
                table: "DmDonVi",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TT_YeuCauLapDanhMucHoSo",
                table: "TT_YeuCauLapDanhMucHoSo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TT_YeuCauLapDanhMucHoSo_DsDonVi",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DmDonVi",
                table: "DmDonVi",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TT_YeuCauLapDanhMucHoSo_Id",
                table: "TT_YeuCauLapDanhMucHoSo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TT_YeuCauLapDanhMucHoSo_DsDonVi_YeuCauId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                column: "YeuCauId");

            migrationBuilder.CreateIndex(
                name: "IX_TT_YeuCauLapDanhMucHoSo_Id",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DmDonVi_Id",
                table: "DmDonVi",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DmDonVi_IdDonViCha",
                table: "DmDonVi",
                column: "IdDonViCha");

            migrationBuilder.CreateIndex(
                name: "IX_DmDonVi_MaDonVi",
                table: "DmDonVi",
                column: "MaDonVi");

            migrationBuilder.CreateIndex(
                name: "IX_DmDonVi_MaDonViCha",
                table: "DmDonVi",
                column: "MaDonViCha");

            migrationBuilder.AddForeignKey(
                name: "FK_DmDonVi_DmDonVi_IdDonViCha",
                table: "DmDonVi",
                column: "IdDonViCha",
                principalTable: "DmDonVi",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TT_YeuCauLapDanhMucHoSo_DsDonVi_TT_YeuCauLapDanhMucHoSo_YeuCauId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                column: "YeuCauId",
                principalTable: "TT_YeuCauLapDanhMucHoSo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DmDonVi_DmDonVi_IdDonViCha",
                table: "DmDonVi");

            migrationBuilder.DropForeignKey(
                name: "FK_TT_YeuCauLapDanhMucHoSo_DsDonVi_TT_YeuCauLapDanhMucHoSo_YeuCauId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TT_YeuCauLapDanhMucHoSo_DsDonVi",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi");

            migrationBuilder.DropIndex(
                name: "IX_TT_YeuCauLapDanhMucHoSo_DsDonVi_YeuCauId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi");

            migrationBuilder.DropIndex(
                name: "IX_TT_YeuCauLapDanhMucHoSo_Id",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TT_YeuCauLapDanhMucHoSo",
                table: "TT_YeuCauLapDanhMucHoSo");

            migrationBuilder.DropIndex(
                name: "IX_TT_YeuCauLapDanhMucHoSo_Id",
                table: "TT_YeuCauLapDanhMucHoSo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DmDonVi",
                table: "DmDonVi");

            migrationBuilder.DropIndex(
                name: "IX_DmDonVi_Id",
                table: "DmDonVi");

            migrationBuilder.DropIndex(
                name: "IX_DmDonVi_IdDonViCha",
                table: "DmDonVi");

            migrationBuilder.DropIndex(
                name: "IX_DmDonVi_MaDonVi",
                table: "DmDonVi");

            migrationBuilder.DropIndex(
                name: "IX_DmDonVi_MaDonViCha",
                table: "DmDonVi");

            migrationBuilder.RenameTable(
                name: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                newName: "TtYeuCauLapDanhMucHoSoDsDonVis");

            migrationBuilder.RenameTable(
                name: "TT_YeuCauLapDanhMucHoSo",
                newName: "TtYeuCauLapDanhMucHoSos");

            migrationBuilder.RenameTable(
                name: "DmDonVi",
                newName: "DonVis");

            migrationBuilder.AlterColumn<string>(
                name: "YeuCauId",
                table: "TtYeuCauLapDanhMucHoSoDsDonVis",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "YeuCauLapDanhMucHoSoId",
                table: "TtYeuCauLapDanhMucHoSoDsDonVis",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaDonViCha",
                table: "DonVis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaDonVi",
                table: "DonVis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdDonViCha",
                table: "DonVis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DonViChaId",
                table: "DonVis",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TtYeuCauLapDanhMucHoSoDsDonVis",
                table: "TtYeuCauLapDanhMucHoSoDsDonVis",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TtYeuCauLapDanhMucHoSos",
                table: "TtYeuCauLapDanhMucHoSos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DonVis",
                table: "DonVis",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TtYeuCauLapDanhMucHoSoDsDonVis_YeuCauLapDanhMucHoSoId",
                table: "TtYeuCauLapDanhMucHoSoDsDonVis",
                column: "YeuCauLapDanhMucHoSoId");

            migrationBuilder.CreateIndex(
                name: "IX_DonVis_DonViChaId",
                table: "DonVis",
                column: "DonViChaId");

            migrationBuilder.AddForeignKey(
                name: "FK_DonVis_DonVis_DonViChaId",
                table: "DonVis",
                column: "DonViChaId",
                principalTable: "DonVis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TtYeuCauLapDanhMucHoSoDsDonVis_TtYeuCauLapDanhMucHoSos_YeuCauLapDanhMucHoSoId",
                table: "TtYeuCauLapDanhMucHoSoDsDonVis",
                column: "YeuCauLapDanhMucHoSoId",
                principalTable: "TtYeuCauLapDanhMucHoSos",
                principalColumn: "Id");
        }
    }
}
