using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface ICTSanPhamService
    {
        Task<List<CTSanPhamVM>> GetAll();
        Task<int> Create(CTSanPhamVM p);
        Task<int> Edit(CTSanPhamVM p);
        Task<int> Delete(int id);
        Task<CTSanPhamVM> GetById(int id);
    }
}
