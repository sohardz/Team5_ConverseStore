using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class CTGioHangServices : ICTGioHangServices
{
    private readonly ShopDbContext _shopDbContext;
    public CTGioHangServices(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<List<CTGioHangVM>> GetAll()
    {
        var query = from p in _shopDbContext.CTGioHangs
                    join pt in _shopDbContext.CTSanPhams on p.IdCtsp equals pt.Id
                    join m in _shopDbContext.GioHangs on p.IdKh equals m.IdKh

                    select new { p, pt, m };
        var data = await query
            .Select(x => new CTGioHangVM()
            {
                Id = x.p.Id,
                IdKh = x.m.IdKh,
                IdCtsp = x.pt.IdSanPham,
                SoLuong = x.p.SoLuong,
                
            }
            ).ToListAsync();
        return data;
    }

    public async Task<List<CTGioHangVM>> GetById(Guid id)
    {
        var lstCTGH = await _shopDbContext.CTGioHangs.Where(x => x.IdKh == id).ToListAsync();
        var lstVM = new List<CTGioHangVM>();

        foreach (var i in lstCTGH)
        {
            var vm = new CTGioHangVM()
            {
                Id = i.Id,
                IdKh = i.IdKh,
                IdCtsp = i.IdCtsp,
                SoLuong = i.SoLuong,
            };
            lstVM.Add(vm);
        }
        return lstVM;
    }

    public async Task<Guid> Edit(Guid idkh, Guid idctsp, CTGioHangVM ctgh)
    {
        //var ctgiohang = await _shopDbContext.CTGioHangs.FindAsync(ctgh.Id);

        //if (ctgiohang == null) throw new ShopExeption($"Can't find a product with id: {ctgh.Id}");
        //ctgiohang.SoLuong = ctgh.SoLuong;
        //_shopDbContext.Update(ctgiohang);
        //await _shopDbContext.SaveChangesAsync();
        //return ctgiohang.Id;

        var listObj = _shopDbContext.CTGioHangs.ToList();
        var objForUpdate = listObj.FirstOrDefault(c => c.IdKh == idkh && c.IdCtsp == idctsp);

        objForUpdate.SoLuong = ctgh.SoLuong;

        _shopDbContext.CTGioHangs.Update(objForUpdate);
        await _shopDbContext.SaveChangesAsync();

        return objForUpdate.Id;

    }

    public async Task<Guid> Create(CTGioHangVM ctgh)
    {
        var ctgiohang = new CTGioHang()
        {
            Id = Guid.NewGuid(),
            SoLuong = ctgh.SoLuong,
            IdKh = ctgh.IdKh,
            IdCtsp = ctgh.IdCtsp,
        };

        await _shopDbContext.CTGioHangs.AddAsync(ctgiohang);
        await _shopDbContext.SaveChangesAsync();
        return ctgiohang.Id;
    }

    public async Task<int> Delete(Guid id)
    {
        var ctgiohang = await _shopDbContext.CTGioHangs.FindAsync(id);
        if (ctgiohang == null)
        {
            throw new ShopExeption($"Không thể tìm thấy sản phẩm với : {id}");
        }
        _shopDbContext.CTGioHangs.Remove(ctgiohang);
        return await _shopDbContext.SaveChangesAsync();
    }
}
