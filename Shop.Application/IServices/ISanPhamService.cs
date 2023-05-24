using Shop.Application.Exeptions;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface ISanPhamService
    {
        public Task<List<SanPhamVM>> GetAllSanPham();
        public Task<SanPhamVM> GetById(int id);
        public Task<int> Sua(SanPhamVM sp);
        public Task<int> Them(SanPhamVM sp);
        public Task<int> Xoa(int id);

    }
}
