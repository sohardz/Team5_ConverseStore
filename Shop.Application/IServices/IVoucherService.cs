using Shop.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.IServices
{
    public interface IVoucherService
    {
        Task<List<VoucherVM>> GetAllVoucher();
        Task<int> Them(VoucherVM v);
        Task<int> Sua(VoucherVM v);
        Task<int> Xoa(int id);
        Task<VoucherVM> GetById(int id);
    }
}
