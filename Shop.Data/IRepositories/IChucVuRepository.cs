using Shop.Data.Models;

namespace Shop.Data.IRepositories;
public interface IChucVuRepository
{
    Task<List<ChucVu>> GetAllAsync();
}
