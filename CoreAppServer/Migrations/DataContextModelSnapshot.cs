﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModificationDate")
                        .HasColumnType("timestamp with time zone");

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
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModificationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PasswordHash = new byte[] { 141, 232, 96, 112, 120, 122, 129, 62, 217, 199, 196, 145, 32, 84, 179, 7, 176, 139, 11, 108, 219, 61, 34, 63, 223, 75, 130, 211, 95, 229, 185, 1, 141, 76, 142, 111, 230, 46, 39, 84, 152, 124, 182, 188, 96, 116, 181, 7, 144, 79, 129, 50, 63, 220, 149, 125, 120, 195, 1, 247, 24, 20, 179, 193 },
                            PasswordSalt = new byte[] { 233, 39, 243, 188, 60, 211, 104, 184, 60, 30, 252, 136, 158, 200, 104, 124, 33, 207, 130, 162, 10, 234, 101, 122, 215, 105, 18, 46, 227, 20, 154, 248, 164, 48, 126, 158, 214, 235, 83, 123, 174, 225, 4, 12, 200, 203, 7, 169, 50, 166, 14, 181, 245, 127, 213, 154, 127, 94, 199, 236, 48, 1, 214, 139, 210, 161, 228, 123, 114, 234, 78, 11, 133, 77, 168, 89, 152, 199, 16, 130, 31, 103, 254, 184, 117, 154, 87, 7, 38, 62, 68, 55, 120, 103, 17, 222, 74, 68, 221, 179, 255, 97, 233, 210, 183, 221, 63, 82, 113, 187, 138, 30, 167, 92, 127, 173, 235, 36, 42, 233, 163, 76, 205, 235, 103, 85, 24, 189 },
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

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<DateTime>("ModificationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("API.Entities.ProductProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductProperties");
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

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("ReceiptId")
                        .HasColumnType("integer");

                    b.Property<int?>("VatRateId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

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

            modelBuilder.Entity("API.Entities.ProductProperties", b =>
                {
                    b.HasOne("API.Entities.Product", "Product")
                        .WithMany("ProductProperties")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
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
                    b.HasOne("API.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("API.Entities.Receipt", "Receipt")
                        .WithMany("ReceiptPositions")
                        .HasForeignKey("ReceiptId");

                    b.HasOne("API.Entities.VatRate", "VatRate")
                        .WithMany()
                        .HasForeignKey("VatRateId");

                    b.Navigation("Product");

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

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.Navigation("ProductProperties");
                });

            modelBuilder.Entity("API.Entities.Receipt", b =>
                {
                    b.Navigation("ReceiptPositions");
                });
#pragma warning restore 612, 618
        }
    }
}
