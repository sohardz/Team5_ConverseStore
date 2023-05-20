using Shop.Application.ViewModels;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface IGioHangService
    {
        Task<List<GioHangVM>>GetAllGioHang();
        Task<int> Them(GioHangVM gh);
        Task<int> Sua(GioHangVM gh);
        Task<int> Xoa(int id);

        Task<GioHangVM> GetById(int id);
    }
}
