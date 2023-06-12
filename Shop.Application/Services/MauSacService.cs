using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class MauSacService : IMauSacService
{
	private readonly ShopDbContext _shopDbContext;
	public MauSacService(ShopDbContext shopDbContext)
	{
		_shopDbContext = shopDbContext;
	}
	public async Task<List<MauSacVM>> GetAll()
	{
		return await _shopDbContext.MauSacs
				.Select(i => new MauSacVM()
				{
					Id = i.Id,
					Ma = i.Ma,
					Ten = i.Ten,
					TrangThai = i.TrangThai,
				}
			).ToListAsync();
	}

	public async Task<MauSacVM> GetById(Guid id)
	{
		var mausac = await _shopDbContext.MauSacs.FindAsync(id);
		var mausacviewmodel = new MauSacVM()
		{
			Id = id,
			Ma = mausac.Ma,
			Ten = mausac.Ten,
			TrangThai = mausac.TrangThai
		};
		return mausacviewmodel;
	}

	public async Task<Guid> Edit(MauSacVM ms)
	{
		var mausac = await _shopDbContext.MauSacs.FindAsync(ms.Id);
		if (mausac == null) throw new ShopExeption($"Không thể tim thấy màu sắc với Id:  {ms.Id}");
		mausac.Ma = ms.Ma;
		mausac.Ten = ms.Ten;
		mausac.TrangThai = ms.TrangThai;
		await _shopDbContext.SaveChangesAsync();
		return mausac.Id;
	}

	public async Task<Guid> Create(MauSacVM ms)
	{
		var mausac = new MauSac()
		{
			Id = Guid.NewGuid(),
			Ma = ms.Ma,
			Ten = ms.Ten,
			TrangThai = ms.TrangThai,
		};
		await _shopDbContext.AddAsync(mausac);
		await _shopDbContext.SaveChangesAsync();
		return mausac.Id;

	}

	public async Task<int> Delete(Guid id)
	{
		var mausac = await _shopDbContext.MauSacs.FindAsync(id);
		if (mausac == null)
		{
			throw new ShopExeption($"Không thể tìm thấy 1 Màu Sắc : {id}");
		}

		_shopDbContext.MauSacs.Remove(mausac);
		return await _shopDbContext.SaveChangesAsync();
	}
}
