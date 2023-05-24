using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IKichCoService
    {
        Task<List<KichCoVM>> GetAllKichCo();
        Task<int> Them(KichCoVM cv);
        Task<int> Sua(KichCoVM cv);
        Task<int> Xoa(int id);

        Task<KichCoVM> GetById(int id);
    }
}
