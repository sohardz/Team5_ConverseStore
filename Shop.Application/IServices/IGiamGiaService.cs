using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IGiamGiaService
    {
        Task<List<GiamGiaVM>> GetAllGiamGia();
        Task<int> Them(GiamGiaVM gg);
        Task<int> Sua(GiamGiaVM gg);
        Task<int> Xoa(int id);

        Task<GiamGiaVM> GetById(int id);
    }
}
