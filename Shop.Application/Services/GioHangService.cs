using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services
{
    public class GioHangService : IGioHangService
    {
        private readonly ShopDbContext _shopDbContext;
        public GioHangService(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<List<GioHangVM>> GetAll()
        {
            return await _shopDbContext.GioHangs
                    .Select(i => new GioHangVM()
                    {
                        IdKh = i.IdKh,
                        MoTa = i.MoTa,
                        TrangThai = i.TrangThai,
                    }
                ).ToListAsync();
        }

        public async Task<GioHangVM> GetById(int id)
        {
            var giohang = await _shopDbContext.GioHangs.FindAsync(id);
            var giohangviewmodel = new GioHangVM()
            {
                IdKh = id,
                MoTa = giohang.MoTa,
                TrangThai = giohang.TrangThai
            };
            return giohangviewmodel;
        }

        public async Task<int> Edit(GioHangVM gh)
        {
            var giohang = await _shopDbContext.GioHangs.FindAsync(gh.IdKh);
            if (giohang == null) throw new ShopExeption($"Không thể tim thấy giỏ hàng với Id:  {gh.IdKh}");

            giohang.MoTa = gh.MoTa;
            giohang.TrangThai = gh.TrangThai;
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> Create(GioHangVM gh)
        {
            var giohang = new GioHang()
            {
                MoTa = gh.MoTa,
                TrangThai = gh.TrangThai,
            };
            _shopDbContext.Add(giohang);
            await _shopDbContext.SaveChangesAsync();
            return giohang.IdKh;
        }

        public async Task<int> Delete(int id)
        {
            var giohang = await _shopDbContext.GioHangs.FindAsync(id);
            if (giohang == null)
            {
                throw new ShopExeption($"Không thể tìm thấy 1 giỏ hàng : {id}");
            }

            _shopDbContext.GioHangs.Remove(giohang);
            return await _shopDbContext.SaveChangesAsync();
        }
    }
}
