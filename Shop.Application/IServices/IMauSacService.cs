using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface IMauSacService
    {
        Task<List<MauSacVM>> GetAll();
        Task<int> Create(MauSacVM cv);
        Task<int> Edit(MauSacVM cv);
        Task<int> Delete(int id);
        Task<MauSacVM> GetById(int id);
    }
}
