using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IMauSacService
{
	Task<List<MauSacVM>> GetAll();
	Task<Guid> Create(MauSacVM cv);
	Task<Guid> Edit(MauSacVM cv);
	Task<int> Delete(Guid id);
	Task<MauSacVM> GetById(Guid id);
}
