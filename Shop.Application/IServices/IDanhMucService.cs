using Shop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface IDanhMucService
    {
        Task<List<DanhMucVM>> GetAllDanhMuc();
        Task<int> Them(DanhMucVM dm);
        Task<int> Sua(DanhMucVM dm);
        Task<int> Xoa(int id);

        Task<DanhMucVM> GetById(int id);
    }
}
