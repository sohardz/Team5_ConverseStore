using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Services
{
    public class SanPhamService : ISanPhamService
    {
        private readonly ShopDbContext _shopDbContext;

        public SanPhamService(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        public async Task<List<SanPhamVM>> GetAll()
        {
            
                var query = from p in _shopDbContext.CTSanPhams
                            join pt in _shopDbContext.SanPhams on p.IdSanPham equals pt.Id
                            join m in _shopDbContext.MauSacs on p.IdMauSac equals m.Id
                            join k in _shopDbContext.KichCos on p.IdKichCo equals k.Id
                            join d in _shopDbContext.DanhMucs on p.IdDanhMuc equals d.Id
                            join g in _shopDbContext.GiamGias on p.IdGiamGia equals g.Id
                            select new { p,pt,m,k,d,g};
                var data = await query
                    .Select(x => new SanPhamVM()
                    {
                        Id = x.p.Id,
                        GiaBan = x.p.GiaBan,
                        GiaNhap = x.p.GiaNhap,
                        SoLuongTon = x.p.SoLuongTon,
                        MoTa = x.p.MoTa,
                        TrangThai = x.p.TrangThai,
                        TenDanhMuc = x.d.Ten,
                        SoSize = x.k.SoSize,
                        MaGiamGia = x.g.Ma,
                        TenMauSac = x.m.Ten,
                        TenSP= x.pt.Ten
                    }
                    ).ToListAsync();
                return data;
            
        }

        public async Task<SanPhamVM> GetById(int ctspId)
        {
            var cTSP = await _shopDbContext.CTSanPhams.FindAsync(ctspId);
            
            var sanPhamViewModel = new SanPhamVM()
            {
               Id = ctspId,
               GiaBan = cTSP.GiaBan,
               GiaNhap = cTSP.GiaNhap,
               SoLuongTon = cTSP.SoLuongTon,
               TrangThai = cTSP.TrangThai,
               
               

            };
            return sanPhamViewModel;
        }

        public Task<int> Sua(SanPhamVM p)
        {
            throw new NotImplementedException();
        }

        public Task<int> Them(SanPhamVM p)
        {
            throw new NotImplementedException();
        }

        public Task<int> Xoa(int id)
        {
            throw new NotImplementedException();
        }
    }
}
