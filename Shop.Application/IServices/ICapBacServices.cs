using Shop.Application.ViewModels;

namespace Shop.Application.IServices;

public interface ICapBacServices
{
    Task<int> Create(CapBacVM cb);
    Task<int> Edit(CapBacVM kh);
    Task<int> Delete(Guid id);
    Task<List<CapBacVM>> GetAll();
    Task<CapBacVM> GetById(Guid id);
}
