using Shop.Data.Models;

namespace Shop.Data.IRepositories;
public interface IKichCoRepository
{
    Task<List<KichCo>> GetAllAsync();
}
