using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IKhachhangServices
    {
        Task<List<KhachHangVM>> GetAll();
        Task<int> Create(KhachHangVM kh);
        Task<int> Edit(KhachHangVM kh);
        Task<int> Delete(int id);
        Task<KhachHangVM> GetById(int id);
    }
}
