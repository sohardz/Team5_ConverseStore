using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface ISanPhamServices
    {
        Task<List<SanPhamVM>> GetAllSanPham();
        Task<int> Them(SanPhamVM p);
        Task<int> Sua(SanPhamVM p);
        Task<int> Xoa(int id);
        Task<SanPhamVM> GetById(int id);
    }
}
