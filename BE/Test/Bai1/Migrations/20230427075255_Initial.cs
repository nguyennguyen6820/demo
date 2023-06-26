using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bai1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EFCORE1");

            migrationBuilder.CreateTable(
                name: "CATEGORY",
                schema: "EFCORE1",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    STATUS = table.Column<decimal>(type: "NUMBER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                schema: "EFCORE1",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "NUMBER", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    PRICE = table.Column<decimal>(type: "NUMBER", nullable: true),
                    STATUS = table.Column<decimal>(type: "NUMBER", nullable: true),
                    CATEGORYID = table.Column<decimal>(type: "NUMBER", nullable: true),
                    CREATEDATE = table.Column<DateTime>(type: "DATE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CATEGORY",
                schema: "EFCORE1");

            migrationBuilder.DropTable(
                name: "PRODUCT",
                schema: "EFCORE1");
        }
    }
}
