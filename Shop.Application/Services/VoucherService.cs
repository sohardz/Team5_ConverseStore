using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class VoucherService : IVoucherService
{
    private readonly ShopDbContext _shopDbContext;
    public VoucherService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<List<VoucherVM>> GetAll()
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

    public async Task<VoucherVM> GetById(Guid id)
    {
        var voucher = await _shopDbContext.Vouchers.FindAsync(id);
        var voucherViewModel = new VoucherVM()
        {
            Id = voucher.Id,
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

    public async Task<int> Edit(VoucherVM v)
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
        _shopDbContext.Update(voucher);
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<int> Create(VoucherVM v)
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
        await _shopDbContext.AddAsync(voucher);
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(Guid id)
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
