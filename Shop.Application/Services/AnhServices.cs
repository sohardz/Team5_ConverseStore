using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services
{
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
                        IdCTSP = i.IdCTSP,
                        DuongDan = i.DuongDan,
                        TrangThai = i.TrangThai,
                    }
                ).ToListAsync();
        }

        public async Task<List<AnhVM>> GetAnhsForGiay(int id)
        {
            return await _shopDbContext.Anhs
                    .Select(i => new AnhVM()
                    {
                        Id = i.Id,
                        IdCTSP = i.IdCTSP,
                        DuongDan = i.DuongDan,
                        TrangThai = i.TrangThai,
                    }
                ).Where(x => x.IdCTSP == id).ToListAsync();
        }

        public async Task<AnhVM> GetById(int id)
        {
            var anh = await _shopDbContext.Anhs.FindAsync(id);
            var anhViewModel = new AnhVM()
            {
                Id = anh.Id,
                IdCTSP = anh.IdCTSP,
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
                IdCTSP = anhVm.IdCTSP,
                DuongDan = anhVm.DuongDan,
                TrangThai = anhVm.TrangThai,
            };
            await _shopDbContext.AddAsync(anh);
            await _shopDbContext.SaveChangesAsync();
            return anh.Id;
        }

        public async Task<int> Delete(int id)
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
}
