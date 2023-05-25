﻿using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        private readonly ShopDbContext _shopDbContext;

        public HoaDonServices(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<int> Create(HoaDonVM p)
        {
            HoaDon hd = new()
            {
                IdKh = p.IdKh,
                IdNv = p.IdNv,
                IdVoucher = p.IdVoucher,
                Ma = p.Ma,
                MaNv = p.MaNv,
                NgayNhan = p.NgayNhan,
                NgayShip = p.NgayShip,
                NgayTao = p.NgayTao,
                NgayThanhToan = p.NgayThanhToan,
                TenKh = p.TenKh,
                DiaChi = p.DiaChi,
                TenNguoiShip = p.TenNguoiShip,
                TongTien = p.TongTien,
                SdtNguoiNhan = p.SdtNguoiNhan,
                SdtNguoiShip = p.SdtNguoiShip,
                PhanTramGiamGia = p.PhanTramGiamGia,
                SoDiemSuDung = p.SoDiemSuDung,
                SoTienQuyDoi = p.SoTienQuyDoi,
                TienShip = p.TienShip,
            };
            await _shopDbContext.AddAsync(hd);
            await _shopDbContext.SaveChangesAsync();
            return p.Id;
        }

        public async Task<int> Delete(int id)
        {
            var hoaDon = await _shopDbContext.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                throw new ShopExeption($"Không thể tìm thấy sản phẩm với : {id}");
            }
            _shopDbContext.HoaDons.Remove(hoaDon);
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> Edit(HoaDonVM p)
        {
            HoaDon hd = await _shopDbContext.HoaDons.FindAsync(p.Id);
            hd.IdKh = p.IdKh;
            hd.IdNv = p.IdNv;
            hd.IdVoucher = p.IdVoucher;
            hd.Ma = p.Ma;
            hd.MaNv = p.MaNv;
            hd.NgayNhan = p.NgayNhan;
            hd.NgayShip = p.NgayShip;
            hd.NgayTao = p.NgayTao;
            hd.NgayThanhToan = p.NgayThanhToan;
            hd.TenKh = p.TenKh;
            hd.DiaChi = p.DiaChi;
            hd.TenNguoiShip = p.TenNguoiShip;
            hd.TongTien = p.TongTien;
            hd.SdtNguoiNhan = p.SdtNguoiNhan;
            hd.SdtNguoiShip = p.SdtNguoiShip;
            hd.PhanTramGiamGia = p.PhanTramGiamGia;
            hd.SoDiemSuDung = p.SoDiemSuDung;
            hd.SoTienQuyDoi = p.SoTienQuyDoi;
            hd.TienShip = p.TienShip;
            _shopDbContext.HoaDons.Update(hd);
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<List<HoaDonVM>> GetAll()
        {
            return await _shopDbContext.HoaDons
                    .Select(p => new HoaDonVM()
                    {
                        Id = p.Id,
                        IdKh = p.IdKh,
                        IdNv = p.IdNv,
                        IdVoucher = p.IdVoucher,
                        Ma = p.Ma,
                        MaNv = p.MaNv,
                        NgayNhan = p.NgayNhan,
                        NgayShip = p.NgayShip,
                        NgayTao = p.NgayTao,
                        NgayThanhToan = p.NgayThanhToan,
                        TenKh = p.TenKh,
                        DiaChi = p.DiaChi,
                        TenNguoiShip = p.TenNguoiShip,
                        TongTien = p.TongTien,
                        SdtNguoiNhan = p.SdtNguoiNhan,
                        SdtNguoiShip = p.SdtNguoiShip,
                        PhanTramGiamGia = p.PhanTramGiamGia,
                        SoDiemSuDung = p.SoDiemSuDung,
                        SoTienQuyDoi = p.SoTienQuyDoi,
                        TienShip = p.TienShip,
                    }
                ).ToListAsync();
        }

        public async Task<HoaDonVM> GetById(int id)
        {
            HoaDon p = await _shopDbContext.HoaDons.FirstOrDefaultAsync(x => x.Id == id);
            HoaDonVM hoaDonVM = new()
            {
                IdKh = p.IdKh,
                IdNv = p.IdNv,
                IdVoucher = p.IdVoucher,
                Ma = p.Ma,
                MaNv = p.MaNv,
                NgayNhan = p.NgayNhan,
                NgayShip = p.NgayShip,
                NgayTao = p.NgayTao,
                NgayThanhToan = p.NgayThanhToan,
                TenKh = p.TenKh,
                DiaChi = p.DiaChi,
                TenNguoiShip = p.TenNguoiShip,
                TongTien = p.TongTien,
                SdtNguoiNhan = p.SdtNguoiNhan,
                SdtNguoiShip = p.SdtNguoiShip,
                PhanTramGiamGia = p.PhanTramGiamGia,
                SoDiemSuDung = p.SoDiemSuDung,
                SoTienQuyDoi = p.SoTienQuyDoi,
                TienShip = p.TienShip,
            };
            return hoaDonVM;
        }
    }
}