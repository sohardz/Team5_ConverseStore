using Shop.Application.ViewModels;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface IKhachhangServices
    {
        Task<List<KhachHangVM>> GetAllKhachhang();
        Task<int> Them(KhachHangVM kh);
        Task<int> Sua(KhachHangVM kh);
        Task<int> Xoa(int id);

        Task<KhachHangVM> GetById(int id);
    }
}
