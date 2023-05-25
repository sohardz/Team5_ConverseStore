using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IChucVuService
    {
        Task<List<ChucVuVM>> GetAll();
        Task<int> Create(ChucVuVM cv);
        Task<int> Edit(ChucVuVM cv);
        Task<int> Delete(int id);
        Task<ChucVuVM> GetById(int id);
    }
}
