using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IGioHangService
{
    Task<List<GioHangVM>> GetAll();
    Task<Guid> Create(GioHangVM gh);
    Task<Guid> Edit(GioHangVM gh);
    Task<int> Delete(Guid id);
    Task<GioHangVM> GetById(Guid id);
}
