using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IHoaDonServices
{
	Task<List<HoaDonVM>> GetAll();
	Task<Guid> Create(HoaDonVM p);
	Task<Guid> Edit(HoaDonVM p);
	Task<int> Delete(Guid id);
	Task<HoaDonVM> GetById(Guid id);
}
