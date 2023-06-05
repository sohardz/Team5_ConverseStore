using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface ICTGioHangServices
{
    Task<List<CTGioHangVM>> GetAll();
    Task<Guid> Create(CTGioHangVM ctgh);
    Task<Guid> Edit(CTGioHangVM ctgh);
    Task<int> Delete(Guid id);
    Task<CTGioHangVM> GetById(Guid id);
}
