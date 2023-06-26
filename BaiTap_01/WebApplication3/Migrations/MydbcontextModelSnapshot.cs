﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using WebApplication3.Db;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(Mydbcontext))]
    partial class MydbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication3.Models.DanhMuc", b =>
                {
                    b.Property<string>("MaDM")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("TenDM")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("MaDM");

                    b.ToTable("DanhMuc");
                });

            modelBuilder.Entity("WebApplication3.Models.SanPham", b =>
                {
                    b.Property<string>("MaSP")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("MaDM")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("TenSP")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("MaSP");

                    b.ToTable("SanPham");
                });
#pragma warning restore 612, 618
        }
    }
}