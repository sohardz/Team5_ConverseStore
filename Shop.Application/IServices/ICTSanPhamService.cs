using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface ICTSanPhamService
{
	Task<List<CTSanPhamVM>> GetAll();
	Task<Guid> Create(CTSanPhamVM p);
	Task<Guid> Edit(CTSanPhamVM p);
	Task<int> Delete(Guid id);
	Task<CTSanPhamVM> GetById(Guid id);
}
