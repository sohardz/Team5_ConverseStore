using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IDanhMucService
{
    Task<List<DanhMucVM>> GetAll();
    Task<int> Create(DanhMucVM dm);
    Task<int> Edit(DanhMucVM dm);
    Task<int> Delete(Guid id);
    Task<DanhMucVM> GetById(Guid id);
}
