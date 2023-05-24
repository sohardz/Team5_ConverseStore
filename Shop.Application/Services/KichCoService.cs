using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services
{
    public class KichCoService : IKichCoService
    {
        private readonly ShopDbContext _shopDbContext;
        public KichCoService(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }



        public async Task<List<KichCoVM>> GetAllKichCo()
        {
            return await _shopDbContext.KichCos
                    .Select(i => new KichCoVM()
                    {
                        Id = i.Id,
                        SoSize = i.SoSize,
                        TrangThai = i.TrangThai,
                    }
                ).ToListAsync();
        }

        public async Task<KichCoVM> GetById(int id)
        {
            var kichco = await _shopDbContext.KichCos.FindAsync(id);
            var kichcoviewmodel = new KichCoVM()
            {
                Id = id,
                SoSize = kichco.SoSize,
                TrangThai = kichco.TrangThai
            };
            return kichcoviewmodel;
        }

        public async Task<int> Sua(KichCoVM kc)
        {
            var kichco = await _shopDbContext.KichCos.FindAsync(kc.Id);
            if (kichco == null) throw new ShopExeption($"Không thể tim thấy Kích Cỡ với Id:  {kc.Id}");

            kichco.SoSize = kc.SoSize;
            kichco.TrangThai = kc.TrangThai;
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> Them(KichCoVM kc)
        {
            var kichco = new KichCo()
            {
                SoSize = kc.SoSize,
                TrangThai = kc.TrangThai,
            };
            _shopDbContext.Add(kichco);
            await _shopDbContext.SaveChangesAsync();
            return kichco.Id;
        }

        public async Task<int> Xoa(int id)
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
}
