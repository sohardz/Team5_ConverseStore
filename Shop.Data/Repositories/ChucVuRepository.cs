using Microsoft.EntityFrameworkCore;
using Shop.Data.Context;
using Shop.Data.IRepositories;
using Shop.Data.Models;

namespace Shop.Data.Repositories;
public class ChucVuRepository : IChucVuRepository
{
    private readonly ShopDbContext _shopDbContext;
    public ChucVuRepository(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }
    public async Task<List<ChucVu>> GetAllAsync()
    {
        return await _shopDbContext.ChucVus.ToListAsync();
    }
}
