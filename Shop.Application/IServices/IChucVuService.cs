using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IChucVuService
{
    Task<List<ChucVuVM>> GetAll();
    Task<int> Create(ChucVuVM cv);
    Task<int> Edit(ChucVuVM cv);
    Task<int> Delete(Guid id);
    Task<ChucVuVM> GetById(Guid id);
}
