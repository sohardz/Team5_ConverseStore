using Shop.Application.ViewModels;

namespace Shop.Application.IServices;

public interface ICTSanPhamService
{
    Task<List<CTSanPhamVM>> GetAll();
    Task<int> Create(CTSanPhamVM p);
    Task<int> Edit(CTSanPhamVM p);
    Task<int> Delete(Guid id);
    Task<CTSanPhamVM> GetById(Guid id);
}
