using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IKhachhangServices
{
    Task<List<KhachHangVM>> GetAll();
    Task<int> Create(KhachHangVM kh);
    Task<int> Edit(KhachHangVM kh);
    Task<int> Delete(Guid id);
    Task<KhachHangVM> GetById(Guid id);
}
