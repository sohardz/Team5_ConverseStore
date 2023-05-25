using Shop.Application.ViewModels;

namespace Shop.Application.IServices
{
    public interface ICTHoaDonServices
    {
        Task<List<CTHoaDonVM>> GetAll(int idhd);
        Task<int> Create(CTHoaDonVM p);
        Task<int> Edit(CTHoaDonVM p);
        Task<int> Delete(int idhd, int idctsp);
        Task<CTHoaDonVM> GetById(int idcthd);
    }
}
