using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IAnhServices
{
    Task<List<AnhVM>> GetAll();
    Task<List<AnhVM>> GetAnhsForGiay(Guid id);
    Task<int> Create(AnhVM cv);
    Task<int> Edit(AnhVM cv);
    Task<int> Delete(Guid id);
    Task<AnhVM> GetById(Guid id);
}
