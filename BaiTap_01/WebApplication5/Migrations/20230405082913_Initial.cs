using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    c_ma_lop = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    c_ten_lop = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.c_ma_lop);
                });

            migrationBuilder.CreateTable(
                name: "SinhVien",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    TenSV = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GioiTinh = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    MaLop = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    LopMaLop1 = table.Column<string>(type: "NVARCHAR2(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhVien", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SinhVien_Lop_LopMaLop1",
                        column: x => x.LopMaLop1,
                        principalTable: "Lop",
                        principalColumn: "c_ma_lop");
                    table.ForeignKey(
                        name: "FK_SinhVien_Lop_MaLop",
                        column: x => x.MaLop,
                        principalTable: "Lop",
                        principalColumn: "c_ma_lop",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_LopMaLop1",
                table: "SinhVien",
                column: "LopMaLop1");

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaLop",
                table: "SinhVien",
                column: "MaLop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinhVien");

            migrationBuilder.DropTable(
                name: "Lop");
        }
    }
}
