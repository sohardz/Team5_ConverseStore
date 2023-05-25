using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IKichCoService
    {
        Task<List<KichCoVM>> GetAll();
        Task<int> Create(KichCoVM cv);
        Task<int> Edit(KichCoVM cv);
        Task<int> Delete(int id);
        Task<KichCoVM> GetById(int id);
    }
}
