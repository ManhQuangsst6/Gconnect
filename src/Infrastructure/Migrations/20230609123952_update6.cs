using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gconnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TT_KeHoachGiaoNop",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKeHoach = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    NguoiLap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TT_KeHoachGiaoNop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TT_KeHoachGiaoNopDonVi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KeHoachGiaoNopId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DonViId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TT_KeHoachGiaoNopDonVi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TT_KeHoachGiaoNopDonVi_TT_KeHoachGiaoNop_KeHoachGiaoNopId",
                        column: x => x.KeHoachGiaoNopId,
                        principalTable: "TT_KeHoachGiaoNop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TT_KeHoachGiaoNop_Id",
                table: "TT_KeHoachGiaoNop",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TT_KeHoachGiaoNopDonVi_Id",
                table: "TT_KeHoachGiaoNopDonVi",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TT_KeHoachGiaoNopDonVi_KeHoachGiaoNopId",
                table: "TT_KeHoachGiaoNopDonVi",
                column: "KeHoachGiaoNopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TT_KeHoachGiaoNopDonVi");

            migrationBuilder.DropTable(
                name: "TT_KeHoachGiaoNop");
        }
    }
}
