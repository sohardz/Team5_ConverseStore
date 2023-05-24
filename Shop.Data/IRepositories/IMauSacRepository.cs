using Shop.Data.Models;

namespace Shop.Data.IRepositories;
public interface IMauSacRepository
{
    Task<List<MauSac>> GetAllAsync();
}
