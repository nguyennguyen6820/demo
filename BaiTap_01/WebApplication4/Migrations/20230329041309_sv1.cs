using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    public partial class sv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lop",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    TenLop = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lop", x => x.MaLop);
                });

            migrationBuilder.CreateTable(
                name: "SInhVien",
                columns: table => new
                {
                    MaSV = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    TenSV = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    GioiTinh = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SInhVien", x => x.MaSV);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lop");

            migrationBuilder.DropTable(
                name: "SInhVien");
        }
    }
}
