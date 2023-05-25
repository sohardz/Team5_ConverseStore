using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface INhanVienServices
    {
        Task<List<NhanVienVM>> GetAll();
        Task<int> Add(NhanVienVM nv);
        Task<int> Update(NhanVienVM nv);
        Task<int> Delete(int id);
        Task<NhanVienVM> GetById(int id);
    }
}
