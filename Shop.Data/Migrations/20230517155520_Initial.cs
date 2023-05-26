using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Data.Migrations;

public partial class Initial : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "CapBac",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                SoDiemCan = table.Column<int>(type: "int", nullable: false),
                TrangThai = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CapBac", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "ChucVus",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
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
            name: "Vouchers",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
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
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
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
                TrangThai = table.Column<int>(type: "int", nullable: false),
                IdBac = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_KhachHangs", x => x.Id);
                table.ForeignKey(
                    name: "FK_KhachHangs_CapBac_IdBac",
                    column: x => x.IdBac,
                    principalTable: "CapBac",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
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
                IdVoucher = table.Column<int>(type: "int", nullable: false),
                Ma = table.Column<string>(type: "varchar(100)", nullable: false),
                MaNv = table.Column<string>(type: "varchar(100)", nullable: false),
                NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                NgayShip = table.Column<DateTime>(type: "datetime2", nullable: false),
                NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_HoaDons_NhanViens_IdVoucher",
                    column: x => x.IdVoucher,
                    principalTable: "NhanViens",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_HoaDons_Vouchers_IdVoucher",
                    column: x => x.IdVoucher,
                    principalTable: "Vouchers",
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
                DonGia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    name: "FK_CTHoaDons_HoaDons_IdHoaDon",
                    column: x => x.IdHoaDon,
                    principalTable: "HoaDons",
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
            name: "IX_CTHoaDons_IdHoaDon",
            table: "CTHoaDons",
            column: "IdHoaDon");

        migrationBuilder.CreateIndex(
            name: "IX_CTHoaDons_IdSanPham",
            table: "CTHoaDons",
            column: "IdSanPham");

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
            name: "CapBac");

        migrationBuilder.DropTable(
            name: "ChucVus");
    }
}
