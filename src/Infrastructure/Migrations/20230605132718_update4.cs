using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gconnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TT_YeuCauLapDanhMucHoSo_DsDonVi_DmDonVi_DonViId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi");

            migrationBuilder.DropTable(
                name: "DmDonVi");

            migrationBuilder.CreateTable(
                name: "DM_DonVi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDonVi = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDonViCha = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaDonViCha = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_DonVi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DM_DonVi_DM_DonVi_IdDonViCha",
                        column: x => x.IdDonViCha,
                        principalTable: "DM_DonVi",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DM_MatHoatDong",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MatHoatDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_MatHoatDong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_Phong",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenPhong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_Phong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DM_ThoiHanBaoQuan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenThoiHanBaoQuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBaoQuan = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_ThoiHanBaoQuan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TT_DanhMucHoSoDuKien",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: true),
                    SoQdPheDuyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayQdPheDuyet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YeuCauLapDanhMucHoSoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TT_DanhMucHoSoDuKien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TT_DanhMucHoSoChiTiet",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DanhMucHoSoDuKienId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhongId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViLapDanhMucId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatHoatDongId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoKyHieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiHanBaoQuanId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiLapId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TT_DanhMucHoSoChiTiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TT_DanhMucHoSoChiTiet_TT_DanhMucHoSoDuKien_DanhMucHoSoDuKienId",
                        column: x => x.DanhMucHoSoDuKienId,
                        principalTable: "TT_DanhMucHoSoDuKien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DmDonVi_Id",
                table: "DM_DonVi",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DmDonVi_IdDonViCha",
                table: "DM_DonVi",
                column: "IdDonViCha");

            migrationBuilder.CreateIndex(
                name: "IX_DmDonVi_MaDonVi",
                table: "DM_DonVi",
                column: "MaDonVi");

            migrationBuilder.CreateIndex(
                name: "IX_DmDonVi_MaDonViCha",
                table: "DM_DonVi",
                column: "MaDonViCha");

            migrationBuilder.CreateIndex(
                name: "IX_DmMatHoatDong_Id",
                table: "DM_MatHoatDong",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DmPhong_Id",
                table: "DM_Phong",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DmThoiHanBaoQuan_Id",
                table: "DM_ThoiHanBaoQuan",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TT_DanhMucHoSoChiTiet_DanhMucHoSoDuKienId",
                table: "TT_DanhMucHoSoChiTiet",
                column: "DanhMucHoSoDuKienId");

            migrationBuilder.CreateIndex(
                name: "IX_TT_DanhMucHoSoChiTiet_Id",
                table: "TT_DanhMucHoSoChiTiet",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TT_DanhMucHoSoDuKien_Id",
                table: "TT_DanhMucHoSoDuKien",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TT_YeuCauLapDanhMucHoSo_DsDonVi_DM_DonVi_DonViId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                column: "DonViId",
                principalTable: "DM_DonVi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TT_YeuCauLapDanhMucHoSo_DsDonVi_DM_DonVi_DonViId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi");

            migrationBuilder.DropTable(
                name: "DM_DonVi");

            migrationBuilder.DropTable(
                name: "DM_MatHoatDong");

            migrationBuilder.DropTable(
                name: "DM_Phong");

            migrationBuilder.DropTable(
                name: "DM_ThoiHanBaoQuan");

            migrationBuilder.DropTable(
                name: "TT_DanhMucHoSoChiTiet");

            migrationBuilder.DropTable(
                name: "TT_DanhMucHoSoDuKien");

            migrationBuilder.CreateTable(
                name: "DmDonVi",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdDonViCha = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDonVi = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MaDonViCha = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TenDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmDonVi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DmDonVi_DmDonVi_IdDonViCha",
                        column: x => x.IdDonViCha,
                        principalTable: "DmDonVi",
                        principalColumn: "Id");
                });

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
                name: "FK_TT_YeuCauLapDanhMucHoSo_DsDonVi_DmDonVi_DonViId",
                table: "TT_YeuCauLapDanhMucHoSo_DsDonVi",
                column: "DonViId",
                principalTable: "DmDonVi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
