using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IVoucherService
    {
        Task<List<VoucherVM>> GetAll();
        Task<int> Create(VoucherVM v);
        Task<int> Edit(VoucherVM v);
        Task<int> Delete(int id);
        Task<VoucherVM> GetById(int id);
    }
}
