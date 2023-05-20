using Shop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface IMauSacService
    {
        Task<List<MauSacVM>> GetAllMauSac();
        Task<int> Them(MauSacVM cv);
        Task<int> Sua(MauSacVM cv);
        Task<int> Xoa(int id);

        Task<MauSacVM> GetById(int id);
    }
}
