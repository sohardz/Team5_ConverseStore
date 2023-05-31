using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class CTHoaDonServices : ICTHoaDonServices
{
    private readonly ShopDbContext _shopDbContext;

    public CTHoaDonServices(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<int> Create(CTHoaDonVM p)
    {
        CTHoaDon ct = new()
        {
            IdHoaDon = p.IdHoaDon,
            IdCtsp = p.IdCtsp,
            SoLuong = p.SoLuong,
            DonGia = p.DonGia,
        };
        await _shopDbContext.AddAsync(ct);
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<int> Delete(Guid idhd, Guid idctsp)
    {
        CTHoaDon ct = await _shopDbContext.CTHoaDons.FirstOrDefaultAsync(x => x.IdHoaDon == idhd && x.IdCtsp == idctsp);
        _shopDbContext.Remove(ct);
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<int> Edit(CTHoaDonVM p)
    {
        CTHoaDon ct = await _shopDbContext.CTHoaDons.FirstOrDefaultAsync(x => x.IdHoaDon == p.IdHoaDon && x.IdCtsp == p.IdCtsp);
        ct.SoLuong = p.SoLuong;
        _shopDbContext.Update(ct);
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<CTHoaDonVM> GetById(Guid idcthd)
    {
        CTHoaDon cthd = await _shopDbContext.CTHoaDons.FirstOrDefaultAsync(x => x.Id == idcthd);
        CTHoaDonVM vm = new()
        {
            IdHoaDon = cthd.IdHoaDon,
            IdCtsp = cthd.IdCtsp,
            SoLuong = cthd.SoLuong,
            DonGia = cthd.DonGia,
        };
        return vm;
    }

    public async Task<List<CTHoaDonVM>> GetAll(Guid idhd)
    {
        return await _shopDbContext.CTHoaDons
            .Select(x => new CTHoaDonVM
            {
                Id = x.Id,
                IdHoaDon = x.IdHoaDon,
                IdCtsp = x.IdCtsp,
                SoLuong = x.SoLuong,
                DonGia = x.DonGia,
            }).Where(x => x.IdHoaDon == idhd).ToListAsync();
    }
}
