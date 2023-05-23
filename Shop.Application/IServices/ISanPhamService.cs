using Shop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface ISanPhamService
    {
        Task<List<SanPhamVM>> GetAll();
        Task<int> Them(SanPhamVM p);
        Task<int> Sua(SanPhamVM p);
        Task<int> Xoa(int id);
        
        Task<SanPhamVM> GetById(int id);
    }
}
