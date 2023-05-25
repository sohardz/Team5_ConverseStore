using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services
{
    public class MauSacService : IMauSacService
    {
        private readonly ShopDbContext _shopDbContext;
        public MauSacService(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<List<MauSacVM>> GetAll()
        {
            return await _shopDbContext.MauSacs
                    .Select(i => new MauSacVM()
                    {
                        Id = i.Id,
                        Ten = i.Ten,
                        TrangThai = i.TrangThai,
                    }
                ).ToListAsync();
        }

        public async Task<MauSacVM> GetById(int id)
        {
            var mausac = await _shopDbContext.MauSacs.FindAsync(id);
            var mausacviewmodel = new MauSacVM()
            {
                Id = id,
                Ten = mausac.Ten,
                TrangThai = mausac.TrangThai
            };
            return mausacviewmodel;
        }

        public async Task<int> Edit(MauSacVM ms)
        {
            var mausac = await _shopDbContext.MauSacs.FindAsync(ms.Id);
            if (mausac == null) throw new ShopExeption($"Không thể tim thấy màu sắc với Id:  {ms.Id}");

            mausac.Ten = ms.Ten;
            mausac.TrangThai = ms.TrangThai;
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> Create(MauSacVM ms)
        {
            var mausac = new MauSac()
            {
                Ten = ms.Ten,
                TrangThai = ms.TrangThai,
            };
            _shopDbContext.Add(mausac);
            await _shopDbContext.SaveChangesAsync();
            return mausac.Id;
        }

        public async Task<int> Delete(int id)
        {
            var mausac = await _shopDbContext.MauSacs.FindAsync(id);
            if (mausac == null)
            {
                throw new ShopExeption($"Không thể tìm thấy 1 Màu Sắc : {id}");
            }

            _shopDbContext.MauSacs.Remove(mausac);
            return await _shopDbContext.SaveChangesAsync();
        }
    }
}
