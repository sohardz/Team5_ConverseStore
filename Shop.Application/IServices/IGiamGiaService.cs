using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IGiamGiaService
{
    Task<List<GiamGiaVM>> GetAll();
    Task<Guid> Create(GiamGiaVM gg);
    Task<Guid> Edit(GiamGiaVM gg);
    Task<int> Delete(Guid id);
    Task<GiamGiaVM> GetById(Guid id);
}
