using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IAnhServices
    {
        Task<List<AnhVM>> GetAllAnh();
        Task<List<AnhVM>> GetAnhsForGiay(int id);
        Task<int> Them(AnhVM cv);
        Task<int> Sua(AnhVM cv);
        Task<int> Xoa(int id);
        Task<AnhVM> GetById(int id);
    }
}
