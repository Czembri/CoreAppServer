﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230518111330_FixAndRoles")]
    partial class FixAndRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = new byte[] { 42, 146, 150, 81, 100, 198, 228, 146, 34, 126, 181, 210, 148, 250, 31, 22, 178, 76, 170, 2, 21, 93, 23, 34, 28, 168, 104, 62, 139, 161, 154, 213, 150, 131, 136, 122, 205, 45, 76, 100, 183, 120, 216, 82, 231, 82, 210, 223, 218, 34, 88, 46, 67, 19, 64, 227, 155, 234, 12, 134, 225, 1, 189, 139 },
                            PasswordSalt = new byte[] { 212, 136, 55, 157, 234, 2, 10, 30, 201, 38, 19, 119, 200, 118, 250, 158, 149, 33, 92, 115, 57, 130, 138, 119, 239, 255, 111, 173, 55, 39, 202, 148, 155, 106, 225, 75, 160, 53, 17, 129, 228, 254, 241, 204, 119, 140, 221, 4, 87, 169, 18, 130, 224, 20, 38, 121, 253, 232, 236, 62, 248, 106, 90, 107, 220, 63, 31, 98, 240, 129, 31, 244, 255, 228, 195, 66, 128, 83, 111, 167, 66, 98, 62, 142, 108, 180, 73, 142, 37, 83, 4, 215, 192, 225, 35, 139, 119, 238, 144, 86, 12, 126, 254, 246, 209, 25, 157, 37, 236, 240, 191, 106, 49, 214, 50, 176, 59, 96, 129, 69, 19, 84, 163, 128, 230, 66, 2, 192 },
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("API.Entities.Browser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ColumnDefinitions")
                        .HasColumnType("text");

                    b.Property<string>("GridOptions")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Browser");
                });

            modelBuilder.Entity("API.Entities.CompanyInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int?>("AppUserId")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<int>("CompanyType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nip")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("CompanyInfo");
                });

            modelBuilder.Entity("API.Entities.PaymentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PaymentType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PaymentInfo");
                });

            modelBuilder.Entity("API.Entities.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("PaymentInfoId")
                        .HasColumnType("integer");

                    b.Property<string>("ReceiptNumber")
                        .HasColumnType("text");

                    b.Property<int?>("ShopId")
                        .HasColumnType("integer");

                    b.Property<string>("Total")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("PaymentInfoId");

                    b.HasIndex("ShopId");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("API.Entities.ReceiptPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Amount")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("ReceiptId")
                        .HasColumnType("integer");

                    b.Property<int?>("VatRateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptId");

                    b.HasIndex("VatRateId");

                    b.ToTable("ReceiptPosition");
                });

            modelBuilder.Entity("API.Entities.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PostalCode")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "",
                            City = "",
                            FirstName = "Admin",
                            LastName = "",
                            PostalCode = "",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("API.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("API.Entities.VatRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Percent")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("VatRate");
                });

            modelBuilder.Entity("API.Entities.CompanyInfo", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("API.Entities.Receipt", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId");

                    b.HasOne("API.Entities.PaymentInfo", "PaymentInfo")
                        .WithMany()
                        .HasForeignKey("PaymentInfoId");

                    b.HasOne("API.Entities.CompanyInfo", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId");

                    b.Navigation("AppUser");

                    b.Navigation("PaymentInfo");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("API.Entities.ReceiptPosition", b =>
                {
                    b.HasOne("API.Entities.Receipt", "Receipt")
                        .WithMany("ReceiptPositions")
                        .HasForeignKey("ReceiptId");

                    b.HasOne("API.Entities.VatRate", "VatRate")
                        .WithMany()
                        .HasForeignKey("VatRateId");

                    b.Navigation("Receipt");

                    b.Navigation("VatRate");
                });

            modelBuilder.Entity("API.Entities.UserInfo", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithOne("UserInfo")
                        .HasForeignKey("API.Entities.UserInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("API.Entities.UserRole", b =>
                {
                    b.HasOne("API.Entities.AppUser", "AppUser")
                        .WithMany("UserRole")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("UserInfo");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("API.Entities.Receipt", b =>
                {
                    b.Navigation("ReceiptPositions");
                });
#pragma warning restore 612, 618
        }
    }
}
