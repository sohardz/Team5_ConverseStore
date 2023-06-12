using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class ChucVuService : IChucVuService
{
	private readonly ShopDbContext _shopDbContext;
	public ChucVuService(ShopDbContext shopDbContext)
	{
		_shopDbContext = shopDbContext;
	}

	public async Task<List<ChucVuVM>> GetAll()
	{
		return await _shopDbContext.ChucVus
				.Select(i => new ChucVuVM()
				{
					Id = i.Id,
					Ma = i.Ma,
					Ten = i.Ten,
					TrangThai = i.TrangThai,
				}
			).ToListAsync();
	}

	public async Task<ChucVuVM> GetById(Guid id)
	{
		var chucvu = await _shopDbContext.ChucVus.FindAsync(id);
		var chucvuviewmodel = new ChucVuVM()
		{
			Id = id,
			Ma = chucvu.Ma,
			Ten = chucvu.Ten,
			TrangThai = chucvu.TrangThai
		};
		return chucvuviewmodel;
	}

	public async Task<Guid> Edit(ChucVuVM cv)
	{
		var chucvu = await _shopDbContext.ChucVus.FindAsync(cv.Id);
		if (chucvu == null) throw new ShopExeption($"Không thể tim thấy chức vụ với Id:  {cv.Id}");
		chucvu.Ma = cv.Ma;
		chucvu.Ten = cv.Ten;
		chucvu.TrangThai = cv.TrangThai;
		await _shopDbContext.SaveChangesAsync();
		return chucvu.Id;
	}

	public async Task<Guid> Create(ChucVuVM cv)
	{
		var chucvu = new ChucVu()
		{
			Id = Guid.NewGuid(),
			Ma = cv.Ma,
			Ten = cv.Ten,
			TrangThai = cv.TrangThai,
		};
		await _shopDbContext.ChucVus.AddAsync(chucvu);
		await _shopDbContext.SaveChangesAsync();
		return chucvu.Id;
	}

	public async Task<int> Delete(Guid id)
	{
		var chucvu = await _shopDbContext.ChucVus.FindAsync(id);
		if (chucvu == null)
		{
			throw new ShopExeption($"Không thể tìm thấy 1 Chuc Vu : {id}");
		}
		_shopDbContext.ChucVus.Remove(chucvu);
		return await _shopDbContext.SaveChangesAsync();

	}
}
