using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services
{
    public class VoucherService : IVoucherService
    {
        private readonly ShopDbContext _shopDbContext;
        public VoucherService(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<List<VoucherVM>> GetAllVoucher()
        {
            return await _shopDbContext.Vouchers
                    .Select(i => new VoucherVM()
                    {
                        Id = i.Id,
                        Ma = i.Ma,
                        Ten = i.Ten,
                        SoTienCan = i.SoTienCan,
                        SoTienGiam = i.SoTienGiam,
                        NgayApDung = i.NgayApDung,
                        NgayKetThuc = i.NgayKetThuc,
                        SoLuong = i.SoLuong,
                        MoTa = i.MoTa,
                        TrangThai = i.TrangThai,
                    }
                ).ToListAsync();
        }

        public async Task<VoucherVM> GetById(int id)
        {
            var voucher = await _shopDbContext.Vouchers.FindAsync(id);
            var voucherViewModel = new VoucherVM()
            {
                Id = id,
                Ma = voucher.Ma,
                Ten = voucher.Ten,
                SoTienCan = voucher.SoTienCan,
                SoTienGiam = voucher.SoTienGiam,
                NgayApDung = voucher.NgayApDung,
                NgayKetThuc = voucher.NgayKetThuc,
                SoLuong = voucher.SoLuong,
                MoTa = voucher.MoTa,
                TrangThai = voucher.TrangThai,
            };
            return voucherViewModel;
        }

        public async Task<int> Sua(VoucherVM v)
        {
            var voucher = await _shopDbContext.Vouchers.FindAsync(v.Id);
            if (voucher == null) throw new ShopExeption($"Không thể tim thấy voucher với Id:  {v.Id}");
            voucher.Ma = v.Ma;
            voucher.Ten = v.Ten;
            voucher.SoTienCan = v.SoTienCan;
            voucher.SoTienGiam = v.SoTienGiam;
            voucher.NgayApDung = v.NgayApDung;
            voucher.NgayKetThuc = v.NgayKetThuc;
            voucher.SoLuong = v.SoLuong;
            voucher.MoTa = v.MoTa;
            voucher.TrangThai = v.TrangThai;

            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> Them(VoucherVM v)
        {
            var voucher = new Voucher()
            {
                Ten = v.Ten,
                SoTienCan = v.SoTienCan,
                SoTienGiam = v.SoTienGiam,
                NgayApDung = v.NgayApDung,
                NgayKetThuc = v.NgayKetThuc,
                SoLuong = v.SoLuong,
                MoTa = v.MoTa,
                TrangThai = v.TrangThai,
            };
            _shopDbContext.Add(voucher);
            await _shopDbContext.SaveChangesAsync();
            return voucher.Id;
        }

        public async Task<int> Xoa(int id)
        {
            var voucher = await _shopDbContext.Vouchers.FindAsync(id);
            if (voucher == null)
            {
                throw new ShopExeption($"Không thể tìm thấy 1 voucher: {id}");
            }

            _shopDbContext.Vouchers.Remove(voucher);
            return await _shopDbContext.SaveChangesAsync();
        }
    }
}
