using Microsoft.EntityFrameworkCore;

using Shop.Data.Models;
using System.Net.WebSockets;

namespace Shop.Data.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        //Danh Muc
        var dmId1 = new Guid("A1EF45D3-64A2-41DB-8E2F-92F94BE68901");
        var dmId2 = new Guid("D2A7E269-21E1-4DEC-969A-B034DDC2CE56");
        modelBuilder.Entity<DanhMuc>().HasData(
                new DanhMuc() { Id = dmId1, Ma = "Loại 1", Ten = "Real", TrangThai = 1 },
                new DanhMuc() { Id = dmId2, Ma = "Loại 2", Ten = "Rep 1:1", TrangThai = 1 });
        //SanPham
        var sp1 = new Guid("9CFE9060-0102-427E-A78F-1D8706FF1DED");
        var sp2 = new Guid("5033BC0F-AFE2-4F74-B15B-F1FCC36D2AA3");
        modelBuilder.Entity<SanPham>().HasData(
                new SanPham() { Id = sp1, Ma = "SP 1", Ten = "Giày Converse", TrangThai = 1 },
                new SanPham() { Id = sp2, Ma = "SP 2", Ten = "Cotton On Ruby ", TrangThai = 1 });
        //Kich Co
        var kc1 = new Guid("1F9EF290-CBA3-4FD5-A5D8-453C1AB422A2");
        var kc2 = new Guid("F342F0A1-7E87-4917-979C-02D5BA80BE80");
        modelBuilder.Entity<KichCo>().HasData(
                new KichCo() { Id = kc1, Ma = "KC 1", SoSize = 40, TrangThai = 1 },
                new KichCo() { Id = kc2, Ma = "KC 2", SoSize = 42, TrangThai = 1 });
        //Mau Sac
        var ms1 = new Guid("A427FF0D-44AC-4194-9C72-CA86F0D84B4E");
        var ms2 = new Guid("2E97D6B9-2F4A-4B41-ACCF-18F86223621D");
        modelBuilder.Entity<MauSac>().HasData(
                new MauSac() { Id = ms1, Ma = "MS 1", Ten = "Trắng", TrangThai = 1 },
                new MauSac() { Id = ms2, Ma = "Ms 2", Ten = "Đen", TrangThai = 1 });
        //Giam Gia
        var g1 = new Guid("408DB8D3-3690-454C-BEF4-BDFE2E6C117A");
        var g2 = new Guid("A0078543-2638-481E-9609-17960504EB63");
        modelBuilder.Entity<GiamGia>().HasData(
                new GiamGia()
                {
                    Id = g1,
                    Ma = "Loại 1",
                    Ten = "Xả hàng",
                    NgayBatDau = new DateTime(2023, 5, 20),
                    NgayKetThuc = new DateTime(2023, 5, 30),
                    MucGiamGiaPhanTram = 10,
                    MucGiamGiaTienMat = 100000,
                    DieuKienGiamGia = "Mười",
                    LoaiGiamGia = 1,
                    TrangThai = 1
                },
                new GiamGia()
                {
                    Id = g2,
                    Ma = "Loại 2",
                    Ten = "Hàng Tồn Kho",
                    NgayBatDau = new DateTime(2023, 5, 20),
                    NgayKetThuc = new DateTime(2023, 5, 30),
                    MucGiamGiaPhanTram = 40,
                    MucGiamGiaTienMat = 200000,
                    DieuKienGiamGia = "Hai",
                    LoaiGiamGia = 2,
                    TrangThai = 1
                });
        //CTSP
        var ctsp1 = new Guid("ED52DAA9-F264-44AF-AF2E-FCF01955F968");
        var ctsp2 = new Guid("93351F9A-EB83-4BC2-969D-A46275A16C7A");
        modelBuilder.Entity<CTSanPham>().HasData(
                new CTSanPham()
                {
                    Id = ctsp1,
                    Ma = "SP 1",
                    IdSanPham = sp1,
                    IdDanhMuc = dmId1,
                    IdGiamGia = g1,
                    IdKichCo = kc1,
                    IdMauSac = ms1,
                    GiaNhap = 1000000,
                    GiaBan = 1500000,
                    SoLuongTon = 100,
                    MoTa = "Sneakers with a sharp-looking minimalist design. Designed with fine details for superb comfort.",
                    TrangThai = 1
                },
                new CTSanPham()
                {
                    Id = ctsp2,
                    Ma = "SP 2",
                    IdSanPham = sp2,
                    IdDanhMuc = dmId2,
                    IdGiamGia = g2,
                    IdKichCo = kc2,
                    IdMauSac = ms2,
                    GiaNhap = 700000,
                    GiaBan = 799000,
                    SoLuongTon = 90,
                    MoTa = "Sneakers with a sharp-looking minimalist design. Designed with fine details for superb comfort.",
                    TrangThai = 1
                });
        //Anh
        var anh1 = new Guid("34C178F4-FA6B-4F5C-BD34-784393A8437A");
        var anh2 = new Guid("DBFA5886-01AB-401F-B671-9A5D1E070E28");
        var anh3 = new Guid("2F355C69-3C5A-42E5-895A-E5093BF41E79");
        var anh4 = new Guid("27CE22AC-FF4E-4442-83E0-6289EF849328");
        var anh5 = new Guid("D6C09720-859C-4A45-9123-D2A9853DD720");
        modelBuilder.Entity<Anh>().HasData(
                new Anh()
                {
                    Id = anh1,
                    Ma = "SP 1",
                    IdCtsp = ctsp1,
                    DuongDan = "/image/1.png",
                    TrangThai = 1
                },
               new Anh()
               {
                   Id = anh2,
                   Ma = "SP 1",
                   IdCtsp = ctsp1,
                   DuongDan = "/image/2.png",
                   TrangThai = 1
               },
               new Anh()
               {
                   Id = anh3,
                   Ma = "SP 1",
                   IdCtsp = ctsp1,
                   DuongDan = "/image/3.png",
                   TrangThai = 1
               },
               new Anh()
               {
                   Id = anh4,
                   Ma = "SP 1",
                   IdCtsp = ctsp1,
                   DuongDan = "/image/4.png",
                   TrangThai = 1
               },
               new Anh()
               {
                   Id = anh5,
                   Ma = "SP 1",
                   IdCtsp = ctsp1,
                   DuongDan = "/image/5.png",
                   TrangThai = 1
               });
        //CapBac
        var cb1 = new Guid("76A8265A-1C5A-4B8C-9A53-C5B2937B9731");
        var cb2 = new Guid("1FA242D3-99C5-4D96-84A7-2A0C42C5F01A");
        var cb3 = new Guid("FB0496FB-AEF3-4693-9CF7-8F66AE988A9B");
        var cb4 = new Guid("8384A802-700C-4040-B80D-744A028A74E0");
        var cb5 = new Guid("894E4300-BE80-489C-AD4B-C81CCA3EF451");
        var cb6 = new Guid("746CB698-ABDC-42A4-8F0C-F6AEA599DFBA");
        modelBuilder.Entity<CapBac>().HasData(
                new CapBac()
                {
                    Id = cb1,
                    Ma = "Hang 1",
                    Ten = "Thân Thiện",
                    SoDiemCan = 0,
                    TrangThai = 1
                },
                new CapBac()
                {
                    Id = cb2,
                    Ma = "Hang 2",
                    Ten = "Đồng",
                    SoDiemCan = 500,
                    TrangThai = 1
                },
                new CapBac()
                {
                    Id = cb3,
                    Ma = "Hang 3",
                    Ten = "Bạc",
                    SoDiemCan = 1000,
                    TrangThai = 1
                },
                new CapBac()
                {
                    Id = cb4,
                    Ma = "Hang 4",
                    Ten = "Vàng",
                    SoDiemCan = 2000,
                    TrangThai = 1
                },
                new CapBac()
                {
                    Id = cb5,
                    Ma = "Hang 5",
                    Ten = "Bạch Kim",
                    SoDiemCan = 5000,
                    TrangThai = 1
                },
                new CapBac()
                {
                    Id = cb6,
                    Ma = "Hang 6",
                    Ten = "Kim Cương",
                    SoDiemCan = 10000,
                    TrangThai = 1
                });
        //Chuc Vu
        var cv1 = new Guid("E0ABFB76-D44C-42E0-8A7A-542E55B874C0");
        var cv2 = new Guid("3698AE73-EAF4-414E-890C-32D7E8073A1C");
        modelBuilder.Entity<ChucVu>().HasData(
                new ChucVu()
                {
                    Id = cv1,
                    Ma = "CV 1",
                    Ten = "Quan Ly",
                    TrangThai = 1
                },
                new ChucVu()
                {
                    Id = cv2,
                    Ma = "CV 2",
                    Ten = "Nhân Viên Bán Hàng",
                    TrangThai = 1
                });

        //Voucher
        var v1 = new Guid("90C348DF-4CFA-428E-873B-8A700340C99A");
        var v2 = new Guid("97078617-27FC-4874-AFAF-1E5E8468FE95");
        modelBuilder.Entity<Voucher>().HasData(
                new Voucher()
                {
                    Id = v1,
                    Ma = "Voucher 1",
                    Ten = "Giảm giá tháng 5 và 6",
                    SoTienCan = 1000000,
                    SoTienGiam = 100000,
                    NgayApDung = new DateTime(2023, 5, 20),
                    NgayKetThuc = new DateTime(2023, 6, 20),
                    MoTa = "Mua một triệu giảm 100000",
                    SoLuong = 100,
                    TrangThai = 1
                },
                new Voucher()
                {
                    Id = v2,
                    Ma = "Voucher 2",
                    Ten = "Giảm giá tháng 5",
                    SoTienCan = 2000000,
                    SoTienGiam = 400000,
                    NgayApDung = new DateTime(2023, 5, 10),
                    NgayKetThuc = new DateTime(2023, 5, 30),
                    MoTa = "Giảm 400000 khi mua hàng đạt 2000000vnd",
                    SoLuong = 50,
                    TrangThai = 1
                });
        //Khách Hàng
        var kh1 = new Guid("9BC9A001-7FA3-4A16-A4EE-34DF4FCC53C5");
        var kh2 = new Guid("C63A7259-0D4D-4D80-80DB-774922C47951");
        modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang()
                {
                    Id = kh1,
                    Ma = "KH 1",
                    HoVaTen = "Nguyễn Kim Học",
                    TenTaiKhoan = "hocnk123",
                    MatKhau = "hoc123456",
                    Email = "hq37na@gmail.com",
                    SoDienThoai = "0395297378",
                    NgaySinh = new DateTime(2003, 7, 19),
                    DiaChi = "Cầu Giấy, Hà Nội",
                    GioiTinh = 1,
                    GhiChu = "Khách hàng thân thiện",
                    IdBac = cb1,
                    SoDiem = 0,
                    TrangThai = 1
                },
               new KhachHang()
               {
                   Id = kh2,
                   Ma = "KH 2",
                   HoVaTen = "Nguyễn Phúc Minh Cương",
                   TenTaiKhoan = "cuongnpm123",
                   MatKhau = "cuong123456",
                   Email = "cuongnpm@gmail.com",
                   SoDienThoai = "0972756511",
                   NgaySinh = new DateTime(2003, 6, 11),
                   DiaChi = "Sóc Sơn, Hà Nội",
                   GioiTinh = 1,
                   GhiChu = "Khách hàng Bạch Kim",
                   IdBac = cb5,
                   SoDiem = 5000,
                   TrangThai = 1
               });


    }
}