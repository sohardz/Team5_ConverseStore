using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class KhachHangServices : IKhachhangServices
{
	private readonly ShopDbContext _shopDbContext;

	public KhachHangServices(ShopDbContext shopDbContext)
	{
		_shopDbContext = shopDbContext;
	}

	public async Task<List<KhachHangVM>> GetAll()
	{
		var query = from k in _shopDbContext.KhachHangs
					join c in _shopDbContext.CapBacs on k.IdBac equals c.Id
					select new { k, c };
		var data = await query
			.Select(x => new KhachHangVM()
			{
				Id = x.k.Id,
				Ma = x.k.Ma,
				HoVaTen = x.k.HoVaTen,
				TenTaiKhoan = x.k.TenTaiKhoan,
				MatKhau = x.k.MatKhau,
				SoDienThoai = x.k.SoDienThoai,
				Email = x.k.Email,
				NgaySinh = x.k.NgaySinh,
				DiaChi = x.k.DiaChi,
				GioiTinh = x.k.GioiTinh,
				GhiChu = x.k.GhiChu,
				TrangThai = x.k.TrangThai,
				IdBac = x.k.IdBac,
				SoDiem = x.k.SoDiem
			}
			).ToListAsync();
		return data;
	}

	public async Task<KhachHangVM> GetById(Guid id)
	{
		var khachHang = await _shopDbContext.KhachHangs.FindAsync(id);
		var khachHangViewmodel = new KhachHangVM()
		{
			Id = id,
			Ma = khachHang.Ma,
			HoVaTen = khachHang.HoVaTen,
			MatKhau = khachHang.MatKhau,
			TenTaiKhoan = khachHang.TenTaiKhoan,
			SoDienThoai = khachHang.SoDienThoai,
			GioiTinh = khachHang.GioiTinh,
			Email = khachHang.Email,
			NgaySinh = khachHang.NgaySinh,
			DiaChi = khachHang.DiaChi,
			GhiChu = khachHang.GhiChu,
			TrangThai = khachHang.TrangThai,
			SoDiem = khachHang.SoDiem,
			IdBac = khachHang.IdBac
		};
		return khachHangViewmodel;
	}

	public async Task<Guid> Edit(KhachHangVM kh)
	{
		var khachhang = await _shopDbContext.KhachHangs.FindAsync(kh.Id);
		if (khachhang == null) throw new ShopExeption($"Không thể tim thấy khách hàng với Id:  {kh.Id}");
		khachhang.Ma = kh.Ma;
		khachhang.HoVaTen = kh.HoVaTen;
		khachhang.MatKhau = kh.MatKhau;
		khachhang.SoDienThoai = kh.SoDienThoai;
		khachhang.Email = kh.Email;
		khachhang.DiaChi = kh.DiaChi;
		khachhang.GhiChu = kh.GhiChu;
		khachhang.GioiTinh = kh.GioiTinh;
		khachhang.NgaySinh = kh.NgaySinh.Value;
		khachhang.IdBac = kh.IdBac;
		khachhang.SoDiem = kh.SoDiem.Value;
		khachhang.TrangThai = kh.TrangThai;
		await _shopDbContext.SaveChangesAsync();
		return khachhang.Id;
	}

	public async Task<Guid> Create(KhachHangVM kh)
	{
		var khachhang = new KhachHang()
		{
			Id = Guid.NewGuid(),
			Ma = kh.Ma,
			HoVaTen = kh.HoVaTen,
			TenTaiKhoan = kh.TenTaiKhoan,
			MatKhau = kh.MatKhau,
			SoDienThoai = kh.SoDienThoai,
			Email = kh.Email,
			DiaChi = kh.DiaChi,
			GhiChu = kh.GhiChu,
			NgaySinh = kh.NgaySinh.Value,
			GioiTinh = kh.GioiTinh,
			SoDiem = 0,
			IdBac = kh.IdBac,
			TrangThai = kh.TrangThai,
		};
		await _shopDbContext.AddAsync(khachhang);
		await _shopDbContext.SaveChangesAsync();
		return khachhang.Id;
	}

	public async Task<int> Delete(Guid id)
	{
		var khachhang = await _shopDbContext.KhachHangs.FindAsync(id);
		if (khachhang == null)
		{
			throw new ShopExeption($"Không thể tìm thấy khách hàng với : {id}");
		}

		_shopDbContext.KhachHangs.Remove(khachhang);
		return await _shopDbContext.SaveChangesAsync();
	}

	public async Task<Guid> CustomerLogin(string username, string password)
	{
		foreach (var i in await GetAll())
		{
			if (i.TenTaiKhoan == username && i.MatKhau == password)
			{
				return (Guid)i.Id;
			}
		}
		return Guid.Empty;
	}
}
