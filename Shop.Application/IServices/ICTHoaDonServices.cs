using Shop.ViewModels.ViewModels;

namespace Shop.Application.IServices;

public interface ICTHoaDonServices
{
    Task<List<CTHoaDonVM>> GetAll(Guid idhd);
    Task<Guid> Create(CTHoaDonVM p);
    Task<Guid> Edit(CTHoaDonVM p);
    Task<int> Delete(Guid idhd, Guid idctsp);
    Task<CTHoaDonVM> GetById(Guid idcthd);
}
