using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IChucVuService
    {
        Task<List<ChucVuVM>> GetAllChucVu();
        Task<int> Them(ChucVuVM cv);
        Task<int> Sua(ChucVuVM cv);
        Task<int> Xoa(int id);
        Task<ChucVuVM> GetById(int id);
    }
}
