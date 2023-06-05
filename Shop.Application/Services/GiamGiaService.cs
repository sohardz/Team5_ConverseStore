using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class GiamGiaService : IGiamGiaService
{
    private readonly ShopDbContext _shopDbContext;
    public GiamGiaService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<List<GiamGiaVM>> GetAll()
    {
        return await _shopDbContext.GiamGias
                 .Select(i => new GiamGiaVM()
                 {
                     Id = i.Id,
                     Ma = i.Ma,
                     Ten = i.Ten,
                     NgayBatDau = i.NgayBatDau,
                     NgayKetThuc = i.NgayKetThuc,
                     MucGiamGiaPhanTram = i.MucGiamGiaPhanTram,
                     MucGiamGiaTienMat = i.MucGiamGiaTienMat,
                     DieuKienGiamGia = i.DieuKienGiamGia,
                     LoaiGiamGia = i.LoaiGiamGia,
                     TrangThai = i.TrangThai,
                 }
             ).ToListAsync();
    }

    public async Task<GiamGiaVM> GetById(Guid id)
    {
        var giamgia = await _shopDbContext.GiamGias.FindAsync(id);
        var giamgiaviewmodel = new GiamGiaVM()
        {
            Id = giamgia.Id,
            Ma = giamgia.Ma,
            Ten = giamgia.Ten,
            NgayBatDau = giamgia.NgayBatDau,
            NgayKetThuc = giamgia.NgayKetThuc,
            MucGiamGiaPhanTram = giamgia.MucGiamGiaPhanTram,
            MucGiamGiaTienMat = giamgia.MucGiamGiaTienMat,
            DieuKienGiamGia = giamgia.DieuKienGiamGia,
            LoaiGiamGia = giamgia.LoaiGiamGia,
            TrangThai = giamgia.TrangThai,
        };
        return giamgiaviewmodel;
    }

    public async Task<Guid> Edit(GiamGiaVM gg)
    {
        var giamgia = await _shopDbContext.GiamGias.FindAsync(gg.Id);
        if (giamgia == null) throw new ShopExeption($"Không thể tim thấy giảm giá với Id:  {gg.Id}");
        giamgia.Ma = gg.Ma;
        giamgia.Ten = gg.Ten;
        giamgia.NgayBatDau = gg.NgayBatDau;
        giamgia.NgayKetThuc = gg.NgayKetThuc;
        giamgia.MucGiamGiaPhanTram = gg.MucGiamGiaPhanTram;
        giamgia.MucGiamGiaTienMat = gg.MucGiamGiaTienMat;
        giamgia.DieuKienGiamGia = gg.DieuKienGiamGia;
        giamgia.LoaiGiamGia = gg.LoaiGiamGia;
        giamgia.TrangThai = 1;

         await _shopDbContext.SaveChangesAsync();
        return giamgia.Id;
    }

    public async Task<Guid> Create(GiamGiaVM gg)
    {
        var giamgia = new GiamGia()
        {
            Id = Guid.NewGuid(),
            Ma = gg.Ma,
            Ten = gg.Ten,
            NgayBatDau = DateTime.Now,
            NgayKetThuc = DateTime.Now,
            MucGiamGiaPhanTram = gg.MucGiamGiaPhanTram,
            MucGiamGiaTienMat = gg.MucGiamGiaTienMat,
            DieuKienGiamGia = gg.DieuKienGiamGia,
            LoaiGiamGia = gg.LoaiGiamGia,
            TrangThai = 1,
        };
        await _shopDbContext.AddAsync(giamgia);
        await _shopDbContext.SaveChangesAsync();
        return giamgia.Id;
    }

    public async Task<int> Delete(Guid id)
    {
        var giamgia = await _shopDbContext.GiamGias.FindAsync(id);
        if (giamgia == null)
        {
            throw new ShopExeption($"Không thể tìm thấy mục giảm giá với : {id}");
        }

        _shopDbContext.GiamGias.Remove(giamgia);
        return await _shopDbContext.SaveChangesAsync();
    }
}
