using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gconnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addyclaphoso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TtYeuCauLapDanhMucHoSos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenYeuCau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: true),
                    TinhTrangPheDuyet = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TtYeuCauLapDanhMucHoSos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TtYeuCauLapDanhMucHoSoDsDonVis",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YeuCauId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonViId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrang = table.Column<int>(type: "int", nullable: true),
                    YeuCauLapDanhMucHoSoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TtYeuCauLapDanhMucHoSoDsDonVis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TtYeuCauLapDanhMucHoSoDsDonVis_TtYeuCauLapDanhMucHoSos_YeuCauLapDanhMucHoSoId",
                        column: x => x.YeuCauLapDanhMucHoSoId,
                        principalTable: "TtYeuCauLapDanhMucHoSos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TtYeuCauLapDanhMucHoSoDsDonVis_YeuCauLapDanhMucHoSoId",
                table: "TtYeuCauLapDanhMucHoSoDsDonVis",
                column: "YeuCauLapDanhMucHoSoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TtYeuCauLapDanhMucHoSoDsDonVis");

            migrationBuilder.DropTable(
                name: "TtYeuCauLapDanhMucHoSos");
        }
    }
}
