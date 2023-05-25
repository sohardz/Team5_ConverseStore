using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IGiamGiaService
    {
        Task<List<GiamGiaVM>> GetAll();
        Task<int> Create(GiamGiaVM gg);
        Task<int> Edit(GiamGiaVM gg);
        Task<int> Delete(int id);
        Task<GiamGiaVM> GetById(int id);
    }
}
