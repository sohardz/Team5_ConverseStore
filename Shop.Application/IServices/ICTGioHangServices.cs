using Shop.Application.ViewModels;

namespace Shop.Application.IServices;

public interface ICTGioHangServices
{
    Task<List<CTGioHangVM>> GetAll();
    Task<int> Create(CTGioHangVM ctgh);
    Task<int> Edit(CTGioHangVM ctgh);
    Task<int> Delete(Guid id);
    Task<CTGioHangVM> GetById(Guid id);
}
