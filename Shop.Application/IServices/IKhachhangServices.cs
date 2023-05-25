using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IKhachhangServices
    {
        Task<List<KhachHangVM>> GetAllKhachhang();
        Task<int> Them(KhachHangVM kh);
        Task<int> Sua(KhachHangVM kh);
        Task<int> Xoa(int id);
        Task<KhachHangVM> GetById(int id);
    }
}
