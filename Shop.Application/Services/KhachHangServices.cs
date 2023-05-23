using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public class KhachHangServices : IKhachhangServices
    {
        private readonly ShopDbContext _shopDbContext;
        public KhachHangServices(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<List<KhachHangVM>> GetAllKhachhang()
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
                    //SoDiemCan = x.c.SoDiemCan
                }
                ).ToListAsync();
            return data;
        }

        public async Task<KhachHangVM> GetById(int id)
        {
            var khachhang = await _shopDbContext.KhachHangs.FindAsync(id);
            var KhachHangVewmodel = new KhachHangVM()
            {
                Id = id,
                Ma = khachhang.Ma,
                HoVaTen = khachhang.HoVaTen,
                MatKhau = khachhang.MatKhau,
                SoDienThoai = khachhang.SoDienThoai,
                Email = khachhang.Email,
                NgaySinh = khachhang.NgaySinh,
                DiaChi = khachhang.DiaChi,
                GhiChu = khachhang.GhiChu,
                TrangThai = khachhang.TrangThai,
                SoDiem = khachhang.SoDiem,
                //IdBac = khachhang.IdBac
            };
            return KhachHangVewmodel;
        }

        public async Task<CapBacVM> GetByIdCapBac(int id)
        {
            var capbac = await _shopDbContext.CapBacs.FindAsync(id);
            var capbacviewmodel = new CapBacVM()
            {
                Id = id,
                Ten = capbac.Ten,
                SoDiemCan= capbac.SoDiemCan,
                TrangThai = capbac.TrangThai,
                
            };
            return capbacviewmodel;
        }

        public async Task<int> Sua(KhachHangVM kh)
        {
            var khachhang = await _shopDbContext.KhachHangs.FindAsync(kh.Id);
            //var capbac = await _shopDbContext.CapBacs.FirstOrDefaultAsync(x => x.Id == kh.IdBac);
            if (khachhang == null ) throw new ShopExeption($"Can't find a customer with id: {kh.Id}");
            khachhang.HoVaTen = kh.HoVaTen;
            khachhang.Email = khachhang.Email;
            khachhang.GioiTinh = kh.GioiTinh;
            khachhang.NgaySinh = kh.NgaySinh;
            khachhang.SoDiem = kh.SoDiem;
            

            return await _shopDbContext.SaveChangesAsync();

        }

        public async Task<int> Them(KhachHangVM kh)
        {
            var khachhangs = _shopDbContext.KhachHangs;
            var khang = new List<KhachHang>();

            var khachhang = new KhachHang()
            {
                Ma = kh.Ma,
                HoVaTen = kh.HoVaTen,
                TenTaiKhoan = kh.TenTaiKhoan,
                MatKhau = kh.MatKhau,
                SoDienThoai = kh.SoDienThoai,
                Email = kh.Email,
                SoDiem = 0,
                NgaySinh = kh.NgaySinh,
                DiaChi = kh.DiaChi,
                GioiTinh = kh.GioiTinh,
                GhiChu = kh.GhiChu,
                TrangThai = kh.TrangThai,
                IdBac = 1
            };
            
            _shopDbContext.KhachHangs.Add(khachhang);
            await _shopDbContext.SaveChangesAsync();
            return khachhang.Id;
        }

        public async Task<int> ThemCapBac(CapBacVM cb)
        {
            var capbac = new CapBac()
            {
                Ten = cb.Ten,
                SoDiemCan = cb.SoDiemCan,
                TrangThai = cb.TrangThai,
            };
            _shopDbContext.CapBacs.Add(capbac);
            await _shopDbContext.SaveChangesAsync();
            return capbac.Id;
        }

        public async Task<int> Xoa(int id)
        {
            var khachhang = await _shopDbContext.KhachHangs.FindAsync(id);
            if (khachhang == null)
            {
                throw new ShopExeption($"Không thể tìm thấy 1 khách hàng với : {id}");
            }
            _shopDbContext.KhachHangs.Remove(khachhang);
            return await _shopDbContext.SaveChangesAsync();
        }
    }
}
