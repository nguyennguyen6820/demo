﻿// <auto-generated />
using Bai4.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bai4.Migrations
{
    [DbContext(typeof(Bai4DbContext))]
    partial class Bai4DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bai4.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<double>("TotalPrices")
                        .HasColumnType("BINARY_DOUBLE");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Bai4.Models.OrderItem", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<double>("Price")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("Quantity")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Bai4.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("Price")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("Quantity")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Bai4.Models.OrderItem", b =>
                {
                    b.HasOne("Bai4.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bai4.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
