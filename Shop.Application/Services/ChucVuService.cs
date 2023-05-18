using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.IRepositories;
using Shop.Data.Models;
using Shop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public class ChucVuService : IChucVuService
    {
        private readonly ShopDbContext _shopDbContext;
        public ChucVuService(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        

        public async Task<List<ChucVuVM>> GetAllChucVu()
        {
            return await _shopDbContext.ChucVus
                    .Select(i=> new ChucVuVM()
                    {
                        Id = i.Id,
                        Ten = i.Ten,
                        TrangThai = i.TrangThai,
                    }
                ).ToListAsync();
        }

        public async Task<ChucVuVM> GetById(int id)
        {
            var chucvu = await _shopDbContext.ChucVus.FindAsync(id);
            var chucvuviewmodel = new ChucVuVM()
            {
                Id = id,
                Ten = chucvu.Ten,
                TrangThai = chucvu.TrangThai
            };
            return chucvuviewmodel;
        }

        public async Task<int> Them(ChucVuVM cv)
        {
            var chucvu = new ChucVu()
            {
                Ten = cv.Ten,
                TrangThai = cv.TrangThai,
            };
            _shopDbContext.Add(chucvu);
            await _shopDbContext.SaveChangesAsync();
            return chucvu.Id;
        }
    }
}
