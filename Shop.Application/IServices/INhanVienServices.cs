using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface INhanVienServices
    {
        Task<List<NhanVienVM>> GetAllNhanVien();
        Task<int> Add(NhanVienVM nv);
    }
}
