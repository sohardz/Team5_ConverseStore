using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IVoucherService
{
    Task<List<VoucherVM>> GetAll();
    Task<int> Create(VoucherVM v);
    Task<int> Edit(VoucherVM v);
    Task<int> Delete(Guid id);
    Task<VoucherVM> GetById(Guid id);
}
