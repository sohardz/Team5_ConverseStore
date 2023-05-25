using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IAnhServices
    {
        Task<List<AnhVM>> GetAll();
        Task<List<AnhVM>> GetAnhsForGiay(int id);
        Task<int> Create(AnhVM cv);
        Task<int> Edit(AnhVM cv);
        Task<int> Delete(int id);
        Task<AnhVM> GetById(int id);
    }
}
