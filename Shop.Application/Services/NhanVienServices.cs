using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;

namespace Shop.Application.Services
{
    public class NhanVienServices : INhanVienServices
    {
        private readonly ShopDbContext _shopDbContext;

        public NhanVienServices(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<int> Add(NhanVienVM nv)
        {
            throw new NotImplementedException();
        }

        public async Task<List<NhanVienVM>> GetAllNhanVien()
        {
            return await _shopDbContext.NhanViens
                .Select(i => new NhanVienVM()
                {
                    Id = i.Id,
                    IdCv = i.IdCv,
                    TenTaiKhoan = i.TenTaiKhoan,

                    TrangThai = i.TrangThai,
                }
            ).ToListAsync();
        }

        public async Task<NhanVienVM> GetById(int id)
        {
            var chucvu = await _shopDbContext.NhanViens.FindAsync(id);
            var chucvuviewmodel = new NhanVienVM()
            {
                Id = id,
                TenTaiKhoan = chucvu.TenTaiKhoan,
                TrangThai = chucvu.TrangThai
            };
            return chucvuviewmodel;
        }
    }
}
