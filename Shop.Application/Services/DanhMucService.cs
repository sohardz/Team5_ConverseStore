using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class DanhMucService : IDanhMucService
{
    private readonly ShopDbContext _shopDbContext;
    public DanhMucService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<List<DanhMucVM>> GetAll()
    {
        return await _shopDbContext.DanhMucs
                .Select(i => new DanhMucVM()
                {
                    Id = i.Id,
                    Ten = i.Ten,
                    TrangThai = i.TrangThai,
                }
            ).ToListAsync();
    }

    public async Task<DanhMucVM> GetById(Guid id)
    {
        var danhMuc = await _shopDbContext.DanhMucs.FindAsync(id);
        var danhMucViewModel = new DanhMucVM()
        {
            Id = id,
            Ten = danhMuc.Ten,
            TrangThai = danhMuc.TrangThai
        };
        return danhMucViewModel;
    }

    public async Task<int> Edit(DanhMucVM dm)
    {
        var danhMuc = await _shopDbContext.DanhMucs.FindAsync(dm.Id);
        if (danhMuc == null) throw new ShopExeption($"Không thể tim thấy danh mục với Id:  {dm.Id}");

        danhMuc.Ten = dm.Ten;
        danhMuc.TrangThai = dm.TrangThai;
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<int> Create(DanhMucVM dm)
    {
        var danhMuc = new DanhMuc()
        {
            Ten = dm.Ten,
            TrangThai = dm.TrangThai,
        };
        await _shopDbContext.AddAsync(danhMuc);
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(Guid id)
    {
        var danhMuc = await _shopDbContext.DanhMucs.FindAsync(id);
        if (danhMuc == null)
        {
            throw new ShopExeption($"Không thể tìm thấy 1 danh mục : {id}");
        }
        _shopDbContext.DanhMucs.Remove(danhMuc);
        return await _shopDbContext.SaveChangesAsync();
    }
}
