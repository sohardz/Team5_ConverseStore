using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services
{
    public class KhachHangServices : IKhachhangServices
    {
        private readonly ShopDbContext _shopDbContext;

        public KhachHangServices(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<List<KhachHangVM>> GetAll()
        {
            var query = from k in _shopDbContext.KhachHangs
                        join c in _shopDbContext.CapBacs on k.IdBac equals c.Id
                        select new { k, c };
            var data = await query
                .Select(x => new KhachHangVM()
                {
                    Id = x.k.Id,
                    Ma = x.k.Ma,
                    HoVaTen = x.k.HoVaTen,
                    TenTaiKhoan = x.k.TenTaiKhoan,
                    MatKhau = x.k.MatKhau,
                    SoDienThoai = x.k.SoDienThoai,
                    Email = x.k.Email,
                    NgaySinh = x.k.NgaySinh,
                    DiaChi = x.k.DiaChi,
                    GioiTinh = x.k.GioiTinh,
                    GhiChu = x.k.GhiChu,
                    TrangThai = x.k.TrangThai,
                    IdBac = x.k.IdBac,
                    SoDiem = x.k.SoDiem
                }
                ).ToListAsync();
            return data;
        }

        public async Task<KhachHangVM> GetById(int id)
        {
            var Khachhang = await _shopDbContext.KhachHangs.FindAsync(id);
            var KhachHangVewmodel = new KhachHangVM()
            {
                Id = id,
                Ma = Khachhang.Ma,
                HoVaTen = Khachhang.HoVaTen,
                MatKhau = Khachhang.MatKhau,
                SoDienThoai = Khachhang.SoDienThoai,
                GioiTinh = Khachhang.GioiTinh,
                Email = Khachhang.Email,
                NgaySinh = Khachhang.NgaySinh,
                DiaChi = Khachhang.DiaChi,
                GhiChu = Khachhang.GhiChu,
                TrangThai = Khachhang.TrangThai,
                IdBac = id
            };
            return KhachHangVewmodel;
        }

        public async Task<int> Edit(KhachHangVM kh)
        {
            var khachhang = await _shopDbContext.KhachHangs.FindAsync(kh.Id);
            if (khachhang == null) throw new ShopExeption($"Không thể tim thấy chức vụ với Id:  {kh.Id}");
            khachhang.HoVaTen = kh.HoVaTen;
            khachhang.MatKhau = kh.MatKhau;
            khachhang.SoDienThoai = kh.SoDienThoai;
            khachhang.Email = kh.Email;
            khachhang.DiaChi = kh.DiaChi;
            khachhang.GhiChu = kh.GhiChu;
            khachhang.GioiTinh = kh.GioiTinh;
            khachhang.NgaySinh = kh.NgaySinh;
            khachhang.IdBac = kh.IdBac;
            khachhang.TrangThai = kh.TrangThai;
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> Create(KhachHangVM kh)
        {
            var khachhang = new KhachHang()
            {
                HoVaTen = kh.HoVaTen,
                TenTaiKhoan = kh.TenTaiKhoan,
                MatKhau = kh.MatKhau,
                SoDienThoai = kh.SoDienThoai,
                Email = kh.Email,
                DiaChi = kh.DiaChi,
                GhiChu = kh.GhiChu,
                NgaySinh = kh.NgaySinh,
                GioiTinh = kh.GioiTinh,
                SoDiem = kh.SoDiem,
                IdBac = kh.IdBac,
                TrangThai = kh.TrangThai,
            };
            await _shopDbContext.AddAsync(khachhang);
            await _shopDbContext.SaveChangesAsync();
            return khachhang.Id;
        }

        public async Task<int> Delete(int id)
        {
            var khachhang = await _shopDbContext.KhachHangs.FindAsync(id);
            if (khachhang == null)
            {
                throw new ShopExeption($"Không thể tìm thấy 1 Chuc Vu : {id}");
            }

            _shopDbContext.KhachHangs.Remove(khachhang);
            return await _shopDbContext.SaveChangesAsync();
        }
    }
}
