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
                name: "CapBacs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDiemCan = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapBacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChucVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MauSacs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ten = table.Column<string>(type: "varchar(100)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "KhachHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "varchar(50)", nullable: false),
                    HoVaTen = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TenTaiKhoan = table.Column<string>(type: "varchar(50)", nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(50)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "varchar(25)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    SoDiem = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    IdBac = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachHangs_CapBacs_IdBac",
                        column: x => x.IdBac,
                        principalTable: "CapBacs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCv = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSanPham = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaNhap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    IdKichCo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMauSac = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDanhMuc = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdGiamGia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                        name: "FK_CTSanPhams_GiamGias_IdGiamGia",
                        column: x => x.IdGiamGia,
                        principalTable: "GiamGias",
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
                name: "GioHangs",
                columns: table => new
                {
                    IdKh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKh = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdNv = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ma = table.Column<string>(type: "varchar(100)", nullable: false),
                    MaNv = table.Column<string>(type: "varchar(100)", nullable: false),
                    MaKh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayShip = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TenKh = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    SdtNguoiNhan = table.Column<string>(type: "varchar(25)", nullable: false),
                    SdtNguoiShip = table.Column<string>(type: "varchar(25)", nullable: false),
                    TenNguoiShip = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    PhanTramGiamGia = table.Column<int>(type: "int", nullable: false),
                    SoDiemSuDung = table.Column<int>(type: "int", nullable: false),
                    SoTienQuyDoi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TienShip = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoaDons_KhachHangs_IdKh",
                        column: x => x.IdKh,
                        principalTable: "KhachHangs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDons_NhanViens_IdNv",
                        column: x => x.IdNv,
                        principalTable: "NhanViens",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HoaDons_Vouchers_IdVoucher",
                        column: x => x.IdVoucher,
                        principalTable: "Vouchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Anhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCtsp = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuongDan = table.Column<string>(type: "varchar(400)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anhs_CTSanPhams_IdCtsp",
                        column: x => x.IdCtsp,
                        principalTable: "CTSanPhams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CTGioHangs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdKh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCtsp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTGioHangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTGioHangs_CTSanPhams_IdCtsp",
                        column: x => x.IdCtsp,
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdHoaDon = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCtsp = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTHoaDons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CTHoaDons_CTSanPhams_IdCtsp",
                        column: x => x.IdCtsp,
                        principalTable: "CTSanPhams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTHoaDons_HoaDons_IdHoaDon",
                        column: x => x.IdHoaDon,
                        principalTable: "HoaDons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CapBacs",
                columns: new[] { "Id", "Ma", "SoDiemCan", "Ten", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("1fa242d3-99c5-4d96-84a7-2a0c42c5f01a"), "Hang 2", 500, "Đồng", 1 },
                    { new Guid("746cb698-abdc-42a4-8f0c-f6aea599dfba"), "Hang 6", 10000, "Kim Cương", 1 },
                    { new Guid("76a8265a-1c5a-4b8c-9a53-c5b2937b9731"), "Hang 1", 0, "Thân Thiện", 1 },
                    { new Guid("8384a802-700c-4040-b80d-744a028a74e0"), "Hang 4", 2000, "Vàng", 1 },
                    { new Guid("894e4300-be80-489c-ad4b-c81cca3ef451"), "Hang 5", 5000, "Bạch Kim", 1 },
                    { new Guid("fb0496fb-aef3-4693-9cf7-8f66ae988a9b"), "Hang 3", 1000, "Bạc", 1 }
                });

            migrationBuilder.InsertData(
                table: "ChucVus",
                columns: new[] { "Id", "Ma", "Ten", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("3698ae73-eaf4-414e-890c-32d7e8073a1c"), "CV 2", "Nhân Viên Bán Hàng", 1 },
                    { new Guid("e0abfb76-d44c-42e0-8a7a-542e55b874c0"), "CV 1", "Quan Ly", 1 }
                });

            migrationBuilder.InsertData(
                table: "DanhMucs",
                columns: new[] { "Id", "Ma", "Ten", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("a1ef45d3-64a2-41db-8e2f-92f94be68901"), "Loại 1", "Real", 1 },
                    { new Guid("d2a7e269-21e1-4dec-969a-b034ddc2ce56"), "Loại 2", "Rep 1:1", 1 }
                });

            migrationBuilder.InsertData(
                table: "GiamGias",
                columns: new[] { "Id", "DieuKienGiamGia", "LoaiGiamGia", "Ma", "MucGiamGiaPhanTram", "MucGiamGiaTienMat", "NgayBatDau", "NgayKetThuc", "Ten", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("408db8d3-3690-454c-bef4-bdfe2e6c117a"), "Mười", 1, "Loại 1", 10, 100000m, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xả hàng", 1 },
                    { new Guid("a0078543-2638-481e-9609-17960504eb63"), "Hai", 2, "Loại 2", 40, 200000m, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hàng Tồn Kho", 1 }
                });

            migrationBuilder.InsertData(
                table: "KichCos",
                columns: new[] { "Id", "Ma", "SoSize", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("1f9ef290-cba3-4fd5-a5d8-453c1ab422a2"), "KC 1", 40, 1 },
                    { new Guid("f342f0a1-7e87-4917-979c-02d5ba80be80"), "KC 2", 42, 1 }
                });

            migrationBuilder.InsertData(
                table: "MauSacs",
                columns: new[] { "Id", "Ma", "Ten", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("2e97d6b9-2f4a-4b41-accf-18f86223621d"), "Ms 2", "Đen", 1 },
                    { new Guid("a427ff0d-44ac-4194-9c72-ca86f0d84b4e"), "MS 1", "Trắng", 1 }
                });

            migrationBuilder.InsertData(
                table: "SanPhams",
                columns: new[] { "Id", "Ma", "Ten", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("5033bc0f-afe2-4f74-b15b-f1fcc36d2aa3"), "SP 2", "Cotton On Ruby ", 1 },
                    { new Guid("9cfe9060-0102-427e-a78f-1d8706ff1ded"), "SP 1", "Giày Converse", 1 }
                });

            migrationBuilder.InsertData(
                table: "Vouchers",
                columns: new[] { "Id", "Ma", "MoTa", "NgayApDung", "NgayKetThuc", "SoLuong", "SoTienCan", "SoTienGiam", "Ten", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("90c348df-4cfa-428e-873b-8a700340c99a"), "Voucher 1", "Mua một triệu giảm 100000", new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1000000m, 100000m, "Giảm giá tháng 5 và 6", 1 },
                    { new Guid("97078617-27fc-4874-afaf-1e5e8468fe95"), "Voucher 2", "Giảm 400000 khi mua hàng đạt 2000000vnd", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 2000000m, 400000m, "Giảm giá tháng 5", 1 }
                });

            migrationBuilder.InsertData(
                table: "CTSanPhams",
                columns: new[] { "Id", "GiaBan", "GiaNhap", "IdDanhMuc", "IdGiamGia", "IdKichCo", "IdMauSac", "IdSanPham", "Ma", "MoTa", "SoLuongTon", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("93351f9a-eb83-4bc2-969d-a46275a16c7a"), 799000m, 700000m, new Guid("d2a7e269-21e1-4dec-969a-b034ddc2ce56"), new Guid("a0078543-2638-481e-9609-17960504eb63"), new Guid("f342f0a1-7e87-4917-979c-02d5ba80be80"), new Guid("2e97d6b9-2f4a-4b41-accf-18f86223621d"), new Guid("5033bc0f-afe2-4f74-b15b-f1fcc36d2aa3"), "SP 2", "Sneakers with a sharp-looking minimalist design. Designed with fine details for superb comfort.", 90, 1 },
                    { new Guid("ed52daa9-f264-44af-af2e-fcf01955f968"), 1500000m, 1000000m, new Guid("a1ef45d3-64a2-41db-8e2f-92f94be68901"), new Guid("408db8d3-3690-454c-bef4-bdfe2e6c117a"), new Guid("1f9ef290-cba3-4fd5-a5d8-453c1ab422a2"), new Guid("a427ff0d-44ac-4194-9c72-ca86f0d84b4e"), new Guid("9cfe9060-0102-427e-a78f-1d8706ff1ded"), "SP 1", "Sneakers with a sharp-looking minimalist design. Designed with fine details for superb comfort.", 100, 1 }
                });

            migrationBuilder.InsertData(
                table: "KhachHangs",
                columns: new[] { "Id", "DiaChi", "Email", "GhiChu", "GioiTinh", "HoVaTen", "IdBac", "Ma", "MatKhau", "NgaySinh", "SoDiem", "SoDienThoai", "TenTaiKhoan", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("9bc9a001-7fa3-4a16-a4ee-34df4fcc53c5"), "Cầu Giấy, Hà Nội", "hq37na@gmail.com", "Khách hàng thân thiện", 1, "Nguyễn Kim Học", new Guid("76a8265a-1c5a-4b8c-9a53-c5b2937b9731"), "KH 1", "hoc123456", new DateTime(2003, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "0395297378", "hocnk123", 1 },
                    { new Guid("c63a7259-0d4d-4d80-80db-774922c47951"), "Sóc Sơn, Hà Nội", "cuongnpm@gmail.com", "Khách hàng Bạch Kim", 1, "Nguyễn Phúc Minh Cương", new Guid("894e4300-be80-489c-ad4b-c81cca3ef451"), "KH 2", "cuong123456", new DateTime(2003, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 5000, "0972756511", "cuongnpm123", 1 }
                });

            migrationBuilder.InsertData(
                table: "Anhs",
                columns: new[] { "Id", "DuongDan", "IdCtsp", "Ma", "TrangThai" },
                values: new object[,]
                {
                    { new Guid("27ce22ac-ff4e-4442-83e0-6289ef849328"), "/image/4.png", new Guid("ed52daa9-f264-44af-af2e-fcf01955f968"), "SP 1", 1 },
                    { new Guid("2f355c69-3c5a-42e5-895a-e5093bf41e79"), "/image/3.png", new Guid("ed52daa9-f264-44af-af2e-fcf01955f968"), "SP 1", 1 },
                    { new Guid("34c178f4-fa6b-4f5c-bd34-784393a8437a"), "/image/1.png", new Guid("ed52daa9-f264-44af-af2e-fcf01955f968"), "SP 1", 1 },
                    { new Guid("d6c09720-859c-4a45-9123-d2a9853dd720"), "/image/5.png", new Guid("ed52daa9-f264-44af-af2e-fcf01955f968"), "SP 1", 1 },
                    { new Guid("dbfa5886-01ab-401f-b671-9a5d1e070e28"), "/image/2.png", new Guid("ed52daa9-f264-44af-af2e-fcf01955f968"), "SP 1", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anhs_IdCtsp",
                table: "Anhs",
                column: "IdCtsp");

            migrationBuilder.CreateIndex(
                name: "IX_CTGioHangs_IdCtsp",
                table: "CTGioHangs",
                column: "IdCtsp");

            migrationBuilder.CreateIndex(
                name: "IX_CTGioHangs_IdKh",
                table: "CTGioHangs",
                column: "IdKh");

            migrationBuilder.CreateIndex(
                name: "IX_CTHoaDons_IdCtsp",
                table: "CTHoaDons",
                column: "IdCtsp");

            migrationBuilder.CreateIndex(
                name: "IX_CTHoaDons_IdHoaDon",
                table: "CTHoaDons",
                column: "IdHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdDanhMuc",
                table: "CTSanPhams",
                column: "IdDanhMuc");

            migrationBuilder.CreateIndex(
                name: "IX_CTSanPhams_IdGiamGia",
                table: "CTSanPhams",
                column: "IdGiamGia");

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
                name: "IX_HoaDons_IdKh",
                table: "HoaDons",
                column: "IdKh");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IdNv",
                table: "HoaDons",
                column: "IdNv");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_IdVoucher",
                table: "HoaDons",
                column: "IdVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHangs_IdBac",
                table: "KhachHangs",
                column: "IdBac");

            migrationBuilder.CreateIndex(
                name: "IX_NhanViens_IdCv",
                table: "NhanViens",
                column: "IdCv");
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
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "CTSanPhams");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "DanhMucs");

            migrationBuilder.DropTable(
                name: "GiamGias");

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
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "CapBacs");

            migrationBuilder.DropTable(
                name: "ChucVus");
        }
    }
}
