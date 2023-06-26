using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication6.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "TEXT", nullable: false),
                    TenLop = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "HocSinh",
                columns: table => new
                {
                    MaHS = table.Column<string>(type: "TEXT", nullable: false),
                    TenHS = table.Column<string>(type: "TEXT", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GioiTinh = table.Column<bool>(type: "INTEGER", nullable: false),
                    MaLop = table.Column<string>(type: "TEXT", nullable: false),
                    LopMaLop = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocSinh", x => x.MaHS);
                    table.ForeignKey(
                        name: "FK_HocSinh_Lop_LopMaLop",
                        column: x => x.LopMaLop,
                        principalTable: "Lop",
                        principalColumn: "MaLop");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HocSinh_LopMaLop",
                table: "HocSinh",
                column: "LopMaLop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HocSinh");

            migrationBuilder.DropTable(
                name: "Lop");
        }
    }
}
