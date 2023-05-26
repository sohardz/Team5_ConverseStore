using Shop.Application.ViewModels;

namespace Shop.Application.IServices;

public interface IGioHangService
{
    Task<List<GioHangVM>> GetAll();
    Task<int> Create(GioHangVM gh);
    Task<int> Edit(GioHangVM gh);
    Task<int> Delete(Guid id);
    Task<GioHangVM> GetById(Guid id);
}
