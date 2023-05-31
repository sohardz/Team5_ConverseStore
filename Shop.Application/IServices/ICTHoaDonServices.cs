using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface ICTHoaDonServices
{
    Task<List<CTHoaDonVM>> GetAll(Guid idhd);
    Task<int> Create(CTHoaDonVM p);
    Task<int> Edit(CTHoaDonVM p);
    Task<int> Delete(Guid idhd, Guid idctsp);
    Task<CTHoaDonVM> GetById(Guid idcthd);
}
