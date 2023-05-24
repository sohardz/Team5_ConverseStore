using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IGioHangService
    {
        Task<List<GioHangVM>> GetAllGioHang();
        Task<int> Them(GioHangVM gh);
        Task<int> Sua(GioHangVM gh);
        Task<int> Xoa(int id);

        Task<GioHangVM> GetById(int id);
    }
}
