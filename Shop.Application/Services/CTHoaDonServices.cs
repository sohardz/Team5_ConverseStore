using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services
{
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
                IdSanPham = p.IdSanPham,
                SoLuong = p.SoLuong,
                DonGia = p.DonGia,
            };
            await _shopDbContext.AddAsync(ct);
            await _shopDbContext.SaveChangesAsync();
            return ct.Id;
        }

        public async Task<int> Delete(int idhd, int idctsp)
        {
            CTHoaDon ct = await _shopDbContext.CTHoaDons.FirstOrDefaultAsync(x => x.IdHoaDon == idhd && x.IdSanPham == idctsp);
            _shopDbContext.Remove(ct);
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> Edit(CTHoaDonVM p)
        {
            CTHoaDon ct = await _shopDbContext.CTHoaDons.FirstOrDefaultAsync(x => x.IdHoaDon == p.IdHoaDon && x.IdSanPham == p.IdSanPham);
            ct.SoLuong = p.SoLuong;
            _shopDbContext.Update(ct);
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<CTHoaDonVM> GetById(int idcthd)
        {
            CTHoaDon cthd = await _shopDbContext.CTHoaDons.FirstOrDefaultAsync(x => x.Id == idcthd);
            CTHoaDonVM vm = new()
            {
                IdHoaDon = cthd.IdHoaDon,
                IdSanPham = cthd.IdSanPham,
                SoLuong = cthd.SoLuong,
                DonGia = cthd.DonGia,
            };
            return vm;
        }

        public async Task<List<CTHoaDonVM>> GetAll(int idhd)
        {
            return await _shopDbContext.CTHoaDons
                .Select(x => new CTHoaDonVM
                {
                    Id = x.Id,
                    IdHoaDon = x.IdHoaDon,
                    IdSanPham = x.IdSanPham,
                    SoLuong = x.SoLuong,
                    DonGia = x.DonGia,
                }).Where(x => x.IdHoaDon == idhd).ToListAsync();
        }
    }
}
