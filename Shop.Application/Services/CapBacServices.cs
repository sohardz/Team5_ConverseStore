using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class CapBacServices : ICapBacServices
{
    private readonly ShopDbContext _shopDbContext;

    public CapBacServices(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<List<CapBacVM>> GetAll()
    {
        return await _shopDbContext.CapBacs
                .Select(i => new CapBacVM()
                {
                    Id = i.Id,
                    Ma = i.Ma,
                    SoDiemCan = i.SoDiemCan,
                    Ten = i.Ten,
                    TrangThai = i.TrangThai,
                }
            ).ToListAsync();
    }

    public async Task<CapBacVM> GetById(Guid id)
    {
        var c = await _shopDbContext.CapBacs.FindAsync(id);
        if(c == null)
        {
            throw new ShopExeption("Không tìm thấy cấp bậc");
        }
        else
        {
            var capBac = new CapBacVM()
            {
                Id = c.Id,
                Ma = c.Ma,
                Ten = c.Ten,
                SoDiemCan = c.SoDiemCan,
                TrangThai = c.TrangThai
            };
            return capBac;
        }
    }

    public async Task<Guid> Create(CapBacVM cb)
    {
        CapBac capBac = new()
        {
            Id = Guid.NewGuid(),
            Ma = cb.Ma,
            Ten = cb.Ten,
            SoDiemCan = cb.SoDiemCan,
            TrangThai = cb.TrangThai,
        };
        await _shopDbContext.CapBacs.AddAsync(capBac);
        await _shopDbContext.SaveChangesAsync();
        return capBac.Id;
    }

    public async Task<Guid> Edit(CapBacVM c)
    {
        var capbac = await _shopDbContext.CapBacs.FindAsync(c.Id);
        if (capbac == null) throw new ShopExeption($"Không thể tim thấy cấp bậc với Id:  {c.Id}");
        capbac.Ma = c.Ma;
        capbac.Ten = c.Ten;
        capbac.TrangThai = c.TrangThai;
        await _shopDbContext.SaveChangesAsync();
        return capbac.Id;
    }

    public async Task<int> Delete(Guid id)
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
