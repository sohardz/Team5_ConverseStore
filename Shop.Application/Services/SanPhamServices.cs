using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services
{
    public class SanPhamServices : ISanPhamService
    {
        private readonly ShopDbContext _shopDbContext;

        public SanPhamServices(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<List<SanPhamVM>> GetAllSanPham()
        {
            return await _shopDbContext.SanPhams
                .Select(i => new SanPhamVM()
                {
                    Id = i.Id,
                    Ten = i.Ten,
                    TrangThai = i.TrangThai,
                }
            ).ToListAsync();
        }

        public async Task<SanPhamVM> GetById(int id)
        {
            var sp = await _shopDbContext.SanPhams.FindAsync(id);
            var sanphamviewmodel = new SanPhamVM()
            {
                Id = id,
                Ten = sp.Ten,
                TrangThai = sp.TrangThai
            };
            return sanphamviewmodel;
        }

        public async Task<int> Sua(SanPhamVM sp)
        {
            var sanpham = await _shopDbContext.SanPhams.FindAsync(sp.Id);
            if (sanpham == null) throw new ShopExeption($"Không thể tim thấy Sản Phẩm với Id:  {sp.Id}");

            sanpham.Ten = sp.Ten;
            sanpham.TrangThai = sp.TrangThai;
            return await _shopDbContext.SaveChangesAsync();
        }

        public async Task<int> Them(SanPhamVM sp)
        {
            var sanpham = new SanPham()
            {
                Ten = sp.Ten,
                TrangThai = sp.TrangThai,
            };
            _shopDbContext.Add(sanpham);
            await _shopDbContext.SaveChangesAsync();
            return sanpham.Id;
        }

        public async Task<int> Xoa(int id)
        {
            var sanpham = await _shopDbContext.SanPhams.FindAsync(id);
            if (sanpham == null)
            {
                throw new ShopExeption($"Không thể tìm thấy 1 Sản Phẩm : {id}");
            }

            _shopDbContext.SanPhams.Remove(sanpham);
            return await _shopDbContext.SaveChangesAsync();
        }
    }
}
