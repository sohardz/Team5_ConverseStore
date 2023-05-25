using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IHoaDonServices
    {
        Task<List<HoaDonVM>> GetAll();
        Task<int> Create(HoaDonVM p);
        Task<int> Edit(HoaDonVM p);
        Task<int> Delete(int id);
        Task<HoaDonVM> GetById(int id);
    }
}
