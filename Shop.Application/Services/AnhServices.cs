using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class AnhServices : IAnhServices
{
    private readonly ShopDbContext _shopDbContext;

    public AnhServices(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<List<AnhVM>> GetAll()
    {
        return await _shopDbContext.Anhs
                .Select(i => new AnhVM()
                {
                    Id = i.Id,
                    IdCtsp = i.IdCtsp,
                    DuongDan = i.DuongDan,
                    TrangThai = i.TrangThai,
                }
            ).ToListAsync();
    }

    public async Task<List<AnhVM>> GetAnhsForGiay(Guid id)
    {
        return await _shopDbContext.Anhs
                .Select(i => new AnhVM()
                {
                    Id = i.Id,
                    IdCtsp = i.IdCtsp,
                    DuongDan = i.DuongDan,
                    TrangThai = i.TrangThai,
                }
            ).Where(x => x.IdCtsp == id).ToListAsync();
    }

    public async Task<AnhVM> GetById(Guid id)
    {
        var anh = await _shopDbContext.Anhs.FindAsync(id);
        var anhViewModel = new AnhVM()
        {
            Id = anh.Id,
            IdCtsp = anh.IdCtsp,
            DuongDan = anh.DuongDan,
            TrangThai = anh.TrangThai,
        };
        return anhViewModel;
    }

    public async Task<int> Edit(AnhVM anhVm)
    {
        var anh = await _shopDbContext.Anhs.FindAsync(anhVm.Id);
        if (anh == null) throw new ShopExeption($"Không thể tim thấy chức vụ với Id:  {anhVm.Id}");
        anh.DuongDan = anhVm.DuongDan;
        anh.TrangThai = anhVm.TrangThai;
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<int> Create(AnhVM anhVm)
    {
        var anh = new Anh()
        {
            IdCtsp = anhVm.IdCtsp,
            DuongDan = anhVm.DuongDan,
            TrangThai = anhVm.TrangThai,
        };
        await _shopDbContext.AddAsync(anh);
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(Guid id)
    {
        var anh = await _shopDbContext.Anhs.FindAsync(id);
        if (anh == null)
        {
            throw new ShopExeption($"Không thể tìm thấy 1 Chuc Vu : {id}");
        }
        _shopDbContext.Anhs.Remove(anh);
        return await _shopDbContext.SaveChangesAsync();
    }
}
