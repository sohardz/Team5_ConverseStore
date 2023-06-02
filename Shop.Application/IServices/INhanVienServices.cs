using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface INhanVienServices
{
    Task<List<NhanVienVM>> GetAll();
    Task<Guid> Create(NhanVienVM nv);
    Task<Guid> Edit(NhanVienVM nv);
    Task<int> Delete(Guid id);
    Task<NhanVienVM> GetById(Guid id);
}
