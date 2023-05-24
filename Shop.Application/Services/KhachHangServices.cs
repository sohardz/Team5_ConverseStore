﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<CapBacVM>> GetAllCapBac()
        {
            return await _shopDbContext.CapBacs
                    .Select(i => new CapBacVM()
                    {
                        Id = i.Id,
                        Ten = i.Ten,
                        TrangThai = i.TrangThai,
                    }
                ).ToListAsync();
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
                Email = Khachhang.Email,
                NgaySinh = Khachhang.NgaySinh,
                DiaChi = Khachhang.DiaChi,
                GhiChu = Khachhang.GhiChu,
                TrangThai = Khachhang.TrangThai,
                IdBac = id
            };
            return KhachHangVewmodel;
        }

        public async Task<int> Sua(KhachHangVM kh)
        {
            var khachhang = await _shopDbContext.KhachHangs.FindAsync(kh.Id);
            if (khachhang == null) throw new ShopExeption($"Không thể tim thấy chức vụ với Id:  {kh.Id}");
            khachhang.HoVaTen = kh.HoVaTen;
            khachhang.MatKhau = kh.MatKhau;
            khachhang.SoDienThoai = kh.SoDienThoai;
            khachhang.Email = kh.Email;
            khachhang.DiaChi = kh.DiaChi;
            khachhang.GhiChu = kh.GhiChu;
            khachhang.TrangThai = kh.TrangThai;
            return await _shopDbContext.SaveChangesAsync();

        }

        public async Task<int> SuaCapBac(CapBacVM c)
        {
            var capbac = await _shopDbContext.CapBacs.FindAsync(c.Id);
            if (capbac == null) throw new ShopExeption($"Không thể tim thấy cấp bậc với Id:  {c.Id}");
            capbac.Ten = c.Ten;
            capbac.TrangThai = c.TrangThai;
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> Them(KhachHangVM kh)
        {
            var khachhang = new KhachHang()
            {
                HoVaTen = kh.HoVaTen,
                TrangThai = kh.TrangThai,
            };
            _shopDbContext.Add(khachhang);
            await _shopDbContext.SaveChangesAsync();
            return khachhang.Id;
        }

        public async Task<int> Xoa(int id)
        {
            var khachhang = await _shopDbContext.KhachHangs.FindAsync(id);
            if (khachhang == null)
            {
                throw new ShopExeption($"Không thể tìm thấy 1 Chuc Vu : {id}");
            }

            _shopDbContext.KhachHangs.Remove(khachhang);
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> XoaCapBac(int id)
        {
            var capBac = await _shopDbContext.CapBacs.FindAsync(id);
            if (capBac == null)
            {
                throw new ShopExeption($"Không thể tìm thấy cấp bậc: {id}");
            }

            _shopDbContext.CapBacs.Remove(capBac);
            return await _shopDbContext.SaveChangesAsync();
        }
    }
}
