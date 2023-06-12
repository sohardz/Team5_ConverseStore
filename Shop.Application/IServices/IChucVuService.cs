using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IChucVuService
{
	Task<List<ChucVuVM>> GetAll();
	Task<Guid> Create(ChucVuVM cv);
	Task<Guid> Edit(ChucVuVM cv);
	Task<int> Delete(Guid id);
	Task<ChucVuVM> GetById(Guid id);
}
