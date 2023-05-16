using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "varchar(100)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GiamGias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MucGiamGiaPhanTram = table.Column<int>(type: "int", nullable: false),
                    MucGiamGiaTienMat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DieuKienGiamGia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiGiamGia = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiamGias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KichCos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoSize = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KichCos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MauSacs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "varchar(100)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuyDoiDiems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TienTichDiem = table.Column<decimal>(type: "decimal", nullable: false),
                    TienTieuDiem = table.Column<decimal>(type: "decimal", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyDoiDiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "varchar(100)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViDiems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongDiem = table.Column<int>(type: "int", nullable: false),
                    SoDiemDaDung = table.Column<int>(type: "int", nullable: false),
                    SoDiemDaCong = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViDiems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhThucGiamGia = table.Column<int>(type: "int", nullable: false),
                    SoTienCan = table.Column<decimal>(type: "decimal", nullable: false),
                    SoTienGiam = table.Column<decimal>(type: "decimal", nullable: false),
                    NgayApDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCv = table.Column<int>(type: "int", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(75)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "varchar(256)", nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(256)", nullable: false),
                    Anh = table.Column<string>(type: "varchar(256)", nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.Id);
                    table.UniqueConstraint("AK_NhanViens_TenTaiKhoan", x => x.TenTaiKhoan);
                    table.ForeignKey(
                        name: "FK_NhanViens_ChucVus_IdCv",
                        column: x => x.IdCv,
                        principalTable: "ChucVus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTSanPhams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    IdKichCo = table.Column<int>(type: "int", nullable: false),
                    IdMauSac = table.Column<int>(type: "int", nullable: false),
                    IdDanhMuc = table.Column<int>(type: "int", nullable: false),
                    IdGiamGia = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTSanPhams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTSanPhams_DanhMucs_IdDanhMuc",
                        column: x => x.IdDanhMuc,
                        principalTable: "DanhMucs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPhams_KichCos_IdKichCo",
                        column: x => x.IdKichCo,
                        principalTable: "KichCos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPhams_MauSacs_IdMauSac",
                        column: x => x.IdMauSac,
                        principalTable: "MauSacs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTSanPhams_SanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "SanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKh = table.Column<string>(type: "varchar(50)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "varchar(50)", nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(50)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "varchar(25)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    SoLanMua = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IdDiem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachHangs_ViDiems_IdDiem",
                        column: x => x.IdDiem,
                        principalTable: "ViDiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anhs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCTSP = table.Column<int>(type: "int", nullable: false),
                    DuongDan = table.Column<string>(type: "varchar(400)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anhs_CTSanPhams_IdCTSP",
                        column: x => x.IdCTSP,
                        principalTable: "CTSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamGiamGias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    IdGiamGia = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoTienConLai = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamGiamGias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanPhamGiamGias_CTSanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "CTSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPhamGiamGias_GiamGias_IdGiamGia",
                        column: x => x.IdGiamGia,
                        principalTable: "GiamGias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    IdKh = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "varchar(400)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.IdKh);
                    table.ForeignKey(
                        name: "FK_GioHangs_KhachHangs_IdKh",
                        column: x => x.IdKh,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKh = table.Column<int>(type: "int", nullable: false),
                    IdNv = table.Column<int>(type: "int", nullable: false),
                    Ma = table.Column<string>(type: "varchar(100)", nullable: false),
                    MaNv = table.Column<string>(type: "varchar(100)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayShip = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenKh = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    SdtNguoiNhan = table.Column<string>(type: "varchar(25)", nullable: false),
                    SdtNguoiShip = table.Column<string>(type: "varchar(25)", nullable: false),
                    TenNguoiShip = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    PhanTramGiamGia = table.Column<int>(type: "int", nullable: false),
                    SoDiemSuDung = table.Column<int>(type: "int", nullable: false),
                    SoTienQuyDoi = table.Column<decimal>(type: "decimal", nullable: false),
                    TienShip = table.Column<decimal>(type: "decimal", nullable: false),
                    KhachHangId = table.Column<int>(type: "int", nullable: true),
                    NhanVienId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDons_NhanViens_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "NhanViens",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VoucherKhachHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVoucher = table.Column<int>(type: "int", nullable: false),
                    IdKh = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherKhachHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherKhachHangs_KhachHangs_IdKh",
                        column: x => x.IdKh,
                        principalTable: "KhachHangs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoucherKhachHangs_Vouchers_IdVoucher",
                        column: x => x.IdVoucher,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTGioHangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdKh = table.Column<int>(type: "int", nullable: false),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTGioHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTGioHangs_CTSanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "CTSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTGioHangs_GioHangs_IdKh",
                        column: x => x.IdKh,
                        principalTable: "GioHangs",
                        principalColumn: "IdKh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTHoaDons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHoaDon = table.Column<int>(type: "int", nullable: false),
                    IdSanPham = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoaDonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTHoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTHoaDons_CTSanPhams_IdSanPham",
                        column: x => x.IdSanPham,
                        principalTable: "CTSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTHoaDons_HoaDons_HoaDonId",
                        column: x => x.HoaDonId,
                        principalTable: "HoaDons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LichSuTieuDiems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoDiemDaDung = table.Column<int>(type: "int", nullable: false),
                    NgaySuDung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoDiemCong = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IdQuyDoi = table.Column<int>(type: "int", nullable: false),
                    IdViDiem = table.Column<int>(type: "int", nullable: false),
                    IdHoaDon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSuTieuDiems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichSuTieuDiems_HoaDons_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichSuTieuDiems_QuyDoiDiems_IdQuyDoi",
                        column: x => x.IdQuyDoi,
                        principalTable: "QuyDoiDiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichSuTieuDiems_ViDiems_IdViDiem",
                        column: x => x.IdViDiem,
                        principalTable: "ViDiems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoucherLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHoaDon = table.Column<int>(type: "int", nullable: false),
                    IdVoucher = table.Column<int>(type: "int", nullable: false),
                    TienTruocGiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoTienGiam = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherLogs_HoaDons_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoucherLogs_Vouchers_IdVoucher",
                        column: x => x.IdVoucher,
                        principalTable: "Vouchers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anhs_IdCTSP",
                table: "Anhs",
                column: "IdCTSP");

            migrationBuilder.CreateIndex(
                name: "IX_CTGioHangs_IdKh",
                table: "CTGioHangs",
                column: "IdKh");

            migrationBuilder.CreateIndex(
                name: "IX_CTGioHangs_IdSanPham",
                table: "CTGioHangs",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_CTHoaDons_HoaDonId",
                table: "CTHoaDons",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_CTHoaDons_IdSanPham",
                table: "CTHoaDons",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdDanhMuc",
                table: "CTSanPhams",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdKichCo",
                table: "CTSanPhams",
                column: "IdKichCo");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdMauSac",
                table: "CTSanPhams",
                column: "IdMauSac");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdSanPham",
                table: "CTSanPhams",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_KhachHangId",
                table: "HoaDons",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_NhanVienId",
                table: "HoaDons",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_IdDiem",
                table: "KhachHangs",
                column: "IdDiem",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichSuTieuDiems_IdHoaDon",
                table: "LichSuTieuDiems",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuTieuDiems_IdQuyDoi",
                table: "LichSuTieuDiems",
                column: "IdQuyDoi");

            migrationBuilder.CreateIndex(
                name: "IX_LichSuTieuDiems_IdViDiem",
                table: "LichSuTieuDiems",
                column: "IdViDiem");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_IdCv",
                table: "NhanViens",
                column: "IdCv");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamGiamGias_IdGiamGia",
                table: "SanPhamGiamGias",
                column: "IdGiamGia");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamGiamGias_IdSanPham",
                table: "SanPhamGiamGias",
                column: "IdSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherKhachHangs_IdKh",
                table: "VoucherKhachHangs",
                column: "IdKh");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherKhachHangs_IdVoucher",
                table: "VoucherKhachHangs",
                column: "IdVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherLogs_IdHoaDon",
                table: "VoucherLogs",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherLogs_IdVoucher",
                table: "VoucherLogs",
                column: "IdVoucher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anhs");

            migrationBuilder.DropTable(
                name: "CTGioHangs");

            migrationBuilder.DropTable(
                name: "CTHoaDons");

            migrationBuilder.DropTable(
                name: "LichSuTieuDiems");

            migrationBuilder.DropTable(
                name: "SanPhamGiamGias");

            migrationBuilder.DropTable(
                name: "VoucherKhachHangs");

            migrationBuilder.DropTable(
                name: "VoucherLogs");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "QuyDoiDiems");

            migrationBuilder.DropTable(
                name: "CTSanPhams");

            migrationBuilder.DropTable(
                name: "GiamGias");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "DanhMucs");

            migrationBuilder.DropTable(
                name: "KichCos");

            migrationBuilder.DropTable(
                name: "MauSacs");

            migrationBuilder.DropTable(
                name: "SanPhams");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "ViDiems");

            migrationBuilder.DropTable(
                name: "ChucVus");
        }
    }
}
