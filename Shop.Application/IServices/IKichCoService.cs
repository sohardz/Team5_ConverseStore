using Shop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface IKichCoService
    {
        Task<List<KichCoVM>> GetAllKichCo();
        Task<int> Them(KichCoVM cv);
        Task<int> Sua(KichCoVM cv);
        Task<int> Xoa(int id);

        Task<KichCoVM> GetById(int id);
    }
}
