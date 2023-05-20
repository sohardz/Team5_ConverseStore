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
       
        public  async Task<List<KhachHangVM>> GetAllKhachhang()
        {
            return await _shopDbContext.KhachHangs
                     .Select(i => new KhachHangVM()
                     {
                         Id = i.Id,
                         Ma=i.Ma,
                         HoVaTen=i.HoVaTen,
                         MatKhau=i.MatKhau,
                         SoDienThoai=i.SoDienThoai,
                         Email=i.Email,
                         NgaySinh=i.NgaySinh,
                         DiaChi=i.DiaChi,
                         GioiTinh=i.GioiTinh,
                         GhiChu=i.GhiChu,
                         TrangThai = i.TrangThai,
                         IdBac=i.IdBac,
                     }
                 ).ToListAsync();
        }

        public async Task<KhachHangVM> GetById(int id)
        {
            var Khachhang = await _shopDbContext.KhachHangs.FindAsync(id);
            var KhachHangVewmodel = new KhachHangVM()
            {
                Id = id,
                Ma=Khachhang.Ma,
                HoVaTen=Khachhang.HoVaTen,
                MatKhau=Khachhang.MatKhau,
                SoDienThoai=Khachhang.SoDienThoai,
                Email=Khachhang.Email,
                NgaySinh=Khachhang.NgaySinh,
                DiaChi=Khachhang.DiaChi,
                GhiChu=Khachhang.GhiChu,
                TrangThai=Khachhang.TrangThai,
                IdBac=id
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
    }
}
