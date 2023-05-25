using Shop.Application.ViewModels;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface ICTGioHangServices
    {
        Task<List<CTGioHangVM>> GetAllCTGioHang();
        Task<int> Them(CTGioHangVM ctgh);
        Task<int> Sua(CTGioHangVM ctgh);
        Task<int> Xoa(int id);

        Task<CTGioHangVM> GetById(int id);
    }
}
