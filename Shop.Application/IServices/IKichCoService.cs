using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IKichCoService
{
	Task<List<KichCoVM>> GetAll();
	Task<Guid> Create(KichCoVM cv);
	Task<Guid> Edit(KichCoVM cv);
	Task<int> Delete(Guid id);
	Task<KichCoVM> GetById(Guid id);
}
