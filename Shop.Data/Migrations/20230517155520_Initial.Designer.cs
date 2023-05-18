﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Data.Context;

#nullable disable

namespace Shop.Data.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20230517155520_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shop.Data.Models.Anh", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DuongDan")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<int>("IdCTSP")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCTSP");

                    b.ToTable("Anhs");
                });

            modelBuilder.Entity("Shop.Data.Models.CapBac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SoDiemCan")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CapBac");
                });

            modelBuilder.Entity("Shop.Data.Models.ChucVu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChucVus");
                });

            modelBuilder.Entity("Shop.Data.Models.CTGioHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdKh")
                        .HasColumnType("int");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdKh");

                    b.HasIndex("IdSanPham");

                    b.ToTable("CTGioHangs");
                });

            modelBuilder.Entity("Shop.Data.Models.CTHoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdHoaDon")
                        .HasColumnType("int");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdHoaDon");

                    b.HasIndex("IdSanPham");

                    b.ToTable("CTHoaDons");
                });

            modelBuilder.Entity("Shop.Data.Models.CTSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("GiaBan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GiaNhap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("IdDanhMuc")
                        .HasColumnType("int");

                    b.Property<int>("IdGiamGia")
                        .HasColumnType("int");

                    b.Property<int>("IdKichCo")
                        .HasColumnType("int");

                    b.Property<int>("IdMauSac")
                        .HasColumnType("int");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDanhMuc");

                    b.HasIndex("IdGiamGia");

                    b.HasIndex("IdKichCo");

                    b.HasIndex("IdMauSac");

                    b.HasIndex("IdSanPham");

                    b.ToTable("CTSanPhams");
                });

            modelBuilder.Entity("Shop.Data.Models.DanhMuc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DanhMucs");
                });

            modelBuilder.Entity("Shop.Data.Models.GiamGia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DieuKienGiamGia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiGiamGia")
                        .HasColumnType("int");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MucGiamGiaPhanTram")
                        .HasColumnType("int");

                    b.Property<decimal>("MucGiamGiaTienMat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GiamGias");
                });

            modelBuilder.Entity("Shop.Data.Models.GioHang", b =>
                {
                    b.Property<int>("IdKh")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("IdKh");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("Shop.Data.Models.HoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("IdKh")
                        .HasColumnType("int");

                    b.Property<int>("IdNv")
                        .HasColumnType("int");

                    b.Property<int>("IdVoucher")
                        .HasColumnType("int");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MaNv")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("NgayNhan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayShip")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<int>("PhanTramGiamGia")
                        .HasColumnType("int");

                    b.Property<string>("SdtNguoiNhan")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("SdtNguoiShip")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<int>("SoDiemSuDung")
                        .HasColumnType("int");

                    b.Property<decimal>("SoTienQuyDoi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TenKh")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("TenNguoiShip")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<decimal>("TienShip")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdKh");

                    b.HasIndex("IdVoucher");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("Shop.Data.Models.KhachHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("IdBac")
                        .HasColumnType("int");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("varchar(25)");

                    b.Property<string>("TenTaiKhoan")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBac");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("Shop.Data.Models.KichCo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SoSize")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("KichCos");
                });

            modelBuilder.Entity("Shop.Data.Models.MauSac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MauSacs");
                });

            modelBuilder.Entity("Shop.Data.Models.NhanVien", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Anh")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("HoVaTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("IdCv")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("TenTaiKhoan")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("TenTaiKhoan");

                    b.HasIndex("IdCv");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("Shop.Data.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("Shop.Data.Models.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("NgayApDung")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<decimal>("SoTienCan")
                        .HasColumnType("decimal");

                    b.Property<decimal>("SoTienGiam")
                        .HasColumnType("decimal");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("Shop.Data.Models.Anh", b =>
                {
                    b.HasOne("Shop.Data.Models.CTSanPham", "CTSanPham")
                        .WithMany("Anhs")
                        .HasForeignKey("IdCTSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CTSanPham");
                });

            modelBuilder.Entity("Shop.Data.Models.CTGioHang", b =>
                {
                    b.HasOne("Shop.Data.Models.GioHang", "GioHang")
                        .WithMany("CTGioHangs")
                        .HasForeignKey("IdKh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.CTSanPham", "CTSanPham")
                        .WithMany("CTGioHangs")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CTSanPham");

                    b.Navigation("GioHang");
                });

            modelBuilder.Entity("Shop.Data.Models.CTHoaDon", b =>
                {
                    b.HasOne("Shop.Data.Models.HoaDon", "HoaDon")
                        .WithMany("CTHoaDons")
                        .HasForeignKey("IdHoaDon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.CTSanPham", "CTSanPham")
                        .WithMany("CTHoaDons")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CTSanPham");

                    b.Navigation("HoaDon");
                });

            modelBuilder.Entity("Shop.Data.Models.CTSanPham", b =>
                {
                    b.HasOne("Shop.Data.Models.DanhMuc", "DanhMuc")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdDanhMuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.GiamGia", "GiamGia")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdGiamGia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.KichCo", "KichCo")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdKichCo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.MauSac", "MauSac")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdMauSac")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.SanPham", "SanPham")
                        .WithMany("CTSanPhams")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMuc");

                    b.Navigation("GiamGia");

                    b.Navigation("KichCo");

                    b.Navigation("MauSac");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("Shop.Data.Models.GioHang", b =>
                {
                    b.HasOne("Shop.Data.Models.KhachHang", "KhachHang")
                        .WithOne("GioHang")
                        .HasForeignKey("Shop.Data.Models.GioHang", "IdKh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("Shop.Data.Models.HoaDon", b =>
                {
                    b.HasOne("Shop.Data.Models.KhachHang", "KhachHang")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdKh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.NhanVien", "NhanVien")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdVoucher")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Data.Models.Voucher", "Voucher")
                        .WithMany("HoaDons")
                        .HasForeignKey("IdVoucher")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("Shop.Data.Models.KhachHang", b =>
                {
                    b.HasOne("Shop.Data.Models.CapBac", "CapBac")
                        .WithMany("KhachHangs")
                        .HasForeignKey("IdBac")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CapBac");
                });

            modelBuilder.Entity("Shop.Data.Models.NhanVien", b =>
                {
                    b.HasOne("Shop.Data.Models.ChucVu", "ChucVu")
                        .WithMany("NhanViens")
                        .HasForeignKey("IdCv")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChucVu");
                });

            modelBuilder.Entity("Shop.Data.Models.CapBac", b =>
                {
                    b.Navigation("KhachHangs");
                });

            modelBuilder.Entity("Shop.Data.Models.ChucVu", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("Shop.Data.Models.CTSanPham", b =>
                {
                    b.Navigation("Anhs");

                    b.Navigation("CTGioHangs");

                    b.Navigation("CTHoaDons");
                });

            modelBuilder.Entity("Shop.Data.Models.DanhMuc", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("Shop.Data.Models.GiamGia", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("Shop.Data.Models.GioHang", b =>
                {
                    b.Navigation("CTGioHangs");
                });

            modelBuilder.Entity("Shop.Data.Models.HoaDon", b =>
                {
                    b.Navigation("CTHoaDons");
                });

            modelBuilder.Entity("Shop.Data.Models.KhachHang", b =>
                {
                    b.Navigation("GioHang");

                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("Shop.Data.Models.KichCo", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("Shop.Data.Models.MauSac", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("Shop.Data.Models.NhanVien", b =>
                {
                    b.Navigation("HoaDons");
                });

            modelBuilder.Entity("Shop.Data.Models.SanPham", b =>
                {
                    b.Navigation("CTSanPhams");
                });

            modelBuilder.Entity("Shop.Data.Models.Voucher", b =>
                {
                    b.Navigation("HoaDons");
                });
#pragma warning restore 612, 618
        }
    }
}