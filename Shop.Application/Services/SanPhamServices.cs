using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class SanPhamServices : ISanPhamService
{
	private readonly ShopDbContext _shopDbContext;

	public SanPhamServices(ShopDbContext shopDbContext)
	{
		_shopDbContext = shopDbContext;
	}

	public async Task<List<SanPhamVM>> GetAll()
	{
		return await _shopDbContext.SanPhams
			.Select(i => new SanPhamVM()
			{
				Id = i.Id,
				Ma = i.Ma,
				Ten = i.Ten,
				TrangThai = i.TrangThai,
			}
		).ToListAsync();
	}

	public async Task<SanPhamVM> GetById(Guid id)
	{
		var sp = await _shopDbContext.SanPhams.FindAsync(id);
		var sanphamviewmodel = new SanPhamVM()
		{
			Id = id,
			Ma = sp.Ma,
			Ten = sp.Ten,
			TrangThai = sp.TrangThai
		};
		return sanphamviewmodel;
	}

	public async Task<Guid> Edit(SanPhamVM sp)
	{
		var sanpham = await _shopDbContext.SanPhams.FindAsync(sp.Id);
		if (sanpham == null) throw new ShopExeption($"Không thể tim thấy Sản Phẩm với Id:  {sp.Id}");
		sanpham.Ma = sp.Ma;
		sanpham.Ten = sp.Ten;
		sanpham.TrangThai = sp.TrangThai;
		await _shopDbContext.SaveChangesAsync();
		return sanpham.Id;
	}

	public async Task<Guid> Create(SanPhamVM sp)
	{
		var sanpham = new SanPham()
		{
			Id = Guid.NewGuid(),
			Ma = sp.Ma,
			Ten = sp.Ten,
			TrangThai = sp.TrangThai,
		};
		await _shopDbContext.AddAsync(sanpham);
		await _shopDbContext.SaveChangesAsync();
		return sanpham.Id;
	}

	public async Task<int> Delete(Guid id)
	{
		var sanpham = await _shopDbContext.SanPhams.FindAsync(id);
		if (sanpham == null)
		{
			throw new ShopExeption($"Không thể tìm thấy 1 Sản Phẩm : {id}");
		}

		_shopDbContext.SanPhams.Remove(sanpham);
		return await _shopDbContext.SaveChangesAsync();
	}
}
