using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IMauSacService
    {
        Task<List<MauSacVM>> GetAllMauSac();
        Task<int> Them(MauSacVM cv);
        Task<int> Sua(MauSacVM cv);
        Task<int> Xoa(int id);

        Task<MauSacVM> GetById(int id);
    }
}
