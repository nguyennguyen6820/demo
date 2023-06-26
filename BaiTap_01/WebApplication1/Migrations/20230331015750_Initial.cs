using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    MaDM = table.Column<string>(type: "TEXT", nullable: false),
                    TenDM = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.MaDM);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSP = table.Column<string>(type: "TEXT", nullable: false),
                    TenSP = table.Column<string>(type: "TEXT", nullable: false),
                    MaDM = table.Column<string>(type: "TEXT", nullable: false),
                    DanhMucMaDM = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SanPham_DanhMuc_DanhMucMaDM",
                        column: x => x.DanhMucMaDM,
                        principalTable: "DanhMuc",
                        principalColumn: "MaDM");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_DanhMucMaDM",
                table: "SanPham",
                column: "DanhMucMaDM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "DanhMuc");
        }
    }
}
