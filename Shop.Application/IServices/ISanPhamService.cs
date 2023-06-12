using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface ISanPhamService
{
	public Task<List<SanPhamVM>> GetAll();
	public Task<SanPhamVM> GetById(Guid id);
	public Task<Guid> Edit(SanPhamVM sp);
	public Task<Guid> Create(SanPhamVM sp);
	public Task<int> Delete(Guid id);
}
