using Shop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface ICTSanPhamService
    {
        Task<List<CTSanPhamVM>> GetAll();
        Task<int> Them(CTSanPhamVM p);
        Task<int> Sua(CTSanPhamVM p);
        Task<int> Xoa(int id);
        
        Task<CTSanPhamVM> GetById(int id);
    }
}
