using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface IKhachhangServices
{
    Task<List<KhachHangVM>> GetAll();
    Task<Guid> Create(KhachHangVM kh);
    Task<Guid> Edit(KhachHangVM kh);
    Task<int> Delete(Guid id);
    Task<KhachHangVM> GetById(Guid id);
    Task<Guid> CustomerLogin(string username, string password);
}
