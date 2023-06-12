using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class DanhMucService : IDanhMucService
{
	private readonly ShopDbContext _shopDbContext;
	public DanhMucService(ShopDbContext shopDbContext)
	{
		_shopDbContext = shopDbContext;
	}

	public async Task<List<DanhMucVM>> GetAll()
	{
		return await _shopDbContext.DanhMucs
				.Select(i => new DanhMucVM()
				{
					Id = i.Id,
					Ma = i.Ma,
					Ten = i.Ten,
					TrangThai = i.TrangThai,
				}
			).ToListAsync();
	}

	public async Task<DanhMucVM> GetById(Guid id)
	{
		var danhMuc = await _shopDbContext.DanhMucs.FindAsync(id);
		if (danhMuc == null)
		{
			throw new ShopExeption("Không tìm thấy danh muc");
		}
		else
		{
			var danhMucViewModel = new DanhMucVM()
			{
				Id = danhMuc.Id,
				Ma = danhMuc.Ma,
				Ten = danhMuc.Ten,
				TrangThai = danhMuc.TrangThai
			};
			return danhMucViewModel;
		};

	}

	public async Task<Guid> Create(DanhMucVM dm)
	{
		DanhMuc danhMuc = new()
		{
			Id = Guid.NewGuid(),
			Ma = dm.Ma,
			Ten = dm.Ten,
			TrangThai = dm.TrangThai,
		};
		await _shopDbContext.AddAsync(danhMuc);
		await _shopDbContext.SaveChangesAsync();
		return danhMuc.Id;
	}

	public async Task<Guid> Edit(DanhMucVM dm)
	{
		var danhMuc = await _shopDbContext.DanhMucs.FindAsync(dm.Id);
		if (danhMuc == null) throw new ShopExeption($"Không thể tim thấy danh mục với Id:  {dm.Id}");
		danhMuc.Ma = dm.Ma;
		danhMuc.Ten = dm.Ten;
		danhMuc.TrangThai = dm.TrangThai;
		await _shopDbContext.SaveChangesAsync();
		return danhMuc.Id;
	}

	public async Task<int> Delete(Guid id)
	{
		var danhMuc = await _shopDbContext.DanhMucs.FindAsync(id);
		if (danhMuc == null)
		{
			throw new ShopExeption($"Không thể tìm thấy danh mục với id : {id}");
		}
		_shopDbContext.DanhMucs.Remove(danhMuc);
		return await _shopDbContext.SaveChangesAsync();
	}
}
