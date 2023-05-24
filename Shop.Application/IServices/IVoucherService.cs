using Shop.Application.ViewModels;

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
