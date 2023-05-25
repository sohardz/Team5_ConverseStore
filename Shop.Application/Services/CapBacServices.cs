using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services
{
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
                        Ten = i.Ten,
                        TrangThai = i.TrangThai,
                    }
                ).ToListAsync();
        }

        public async Task<CapBacVM> GetById(int id)
        {
            var c = await _shopDbContext.CapBacs.FindAsync(id);
            var capBac = new CapBacVM()
            {
                Id = id,
                Ten = c.Ten,
                SoDiemCan = c.SoDiemCan,
                TrangThai = c.TrangThai
            };
            return capBac;
        }

        public async Task<int> Create(CapBacVM c)
        {
            CapBac capBac = new()
            {
                Ten = c.Ten,
                SoDiemCan = c.SoDiemCan,
                TrangThai = c.TrangThai,
            };
            await _shopDbContext.CapBacs.AddAsync(capBac);
            await _shopDbContext.SaveChangesAsync();
            return capBac.Id;
        }

        public async Task<int> Edit(CapBacVM c)
        {
            var capbac = await _shopDbContext.CapBacs.FindAsync(c.Id);
            if (capbac == null) throw new ShopExeption($"Không thể tim thấy cấp bậc với Id:  {c.Id}");
            capbac.Ten = c.Ten;
            capbac.TrangThai = c.TrangThai;
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
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
}
