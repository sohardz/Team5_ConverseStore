using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class KichCoService : IKichCoService
{
    private readonly ShopDbContext _shopDbContext;
    public KichCoService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<List<KichCoVM>> GetAll()
    {
        return await _shopDbContext.KichCos
                .Select(i => new KichCoVM()
                {
                    Id = i.Id,
                    Ma = i.Ma,
                    SoSize = i.SoSize,
                    TrangThai = i.TrangThai,
                }
            ).ToListAsync();
    }

    public async Task<KichCoVM> GetById(Guid id)
    {
        var kichco = await _shopDbContext.KichCos.FindAsync(id);
        var kichcoviewmodel = new KichCoVM()
        {
            Id = id,
            Ma = kichco.Ma,
            SoSize = kichco.SoSize,
            TrangThai = kichco.TrangThai
        };
        return kichcoviewmodel;
    }

    public async Task<Guid> Edit(KichCoVM kc)
    {
        var kichco = await _shopDbContext.KichCos.FindAsync(kc.Id);
        if (kichco == null) throw new ShopExeption($"Không thể tim thấy Kích Cỡ với Id:  {kc.Id}");
        kichco.Ma = kc.Ma;
        kichco.SoSize = kc.SoSize;
        kichco.TrangThai = kc.TrangThai;
         await _shopDbContext.SaveChangesAsync();
        return kichco.Id;
    }

    public async Task<Guid> Create(KichCoVM kc)
    {
        var kichco = new KichCo()
        {
            Id = Guid.NewGuid(),
            Ma = kc.Ma,
            SoSize = kc.SoSize,
            TrangThai = kc.TrangThai,
        };
        await _shopDbContext.AddAsync(kichco);
         await _shopDbContext.SaveChangesAsync();
        return kichco.Id;

    }

    public async Task<int> Delete(Guid id)
    {
        var kichco = await _shopDbContext.KichCos.FindAsync(id);
        if (kichco == null)
        {
            throw new ShopExeption($"Không thể tìm thấy 1 Kích Cỡ : {id}");
        }

        _shopDbContext.KichCos.Remove(kichco);
        return await _shopDbContext.SaveChangesAsync();
    }
}
