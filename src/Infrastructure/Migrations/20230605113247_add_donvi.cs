using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gconnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adddonvi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonVis",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDonVi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDonViCha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDonViCha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViChaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonVis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonVis_DonVis_DonViChaId",
                        column: x => x.DonViChaId,
                        principalTable: "DonVis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonVis_DonViChaId",
                table: "DonVis",
                column: "DonViChaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonVis");
        }
    }
}
