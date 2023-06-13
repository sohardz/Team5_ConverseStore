using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class HoaDonServices : IHoaDonServices
{
	private readonly ShopDbContext _shopDbContext;

	public HoaDonServices(ShopDbContext shopDbContext)
	{
		_shopDbContext = shopDbContext;
	}

	public async Task<Guid> Create(HoaDonVM p)
	{
		HoaDon hd = new()
		{
			Id = Guid.NewGuid(),
			IdKh = p.IdKh,
			IdVoucher = p.IdVoucher,
			Ma = p.Ma,
			MaKh = p.MaKh,
			NgayNhan = p.NgayNhan,
			NgayShip = p.NgayShip,
			NgayTao = p.NgayTao,
			NgayThanhToan = p.NgayThanhToan,
			TenKh = p.TenKh,
			DiaChi = p.DiaChi,
			TenNguoiShip = p.TenNguoiShip,
			TongTien = p.TongTien,
			SdtNguoiNhan = p.SdtNguoiNhan,
			SdtNguoiShip = p.SdtNguoiShip,
			PhanTramGiamGia = p.PhanTramGiamGia,
			SoDiemSuDung = p.SoDiemSuDung,
			SoTienQuyDoi = p.SoTienQuyDoi,
			TienShip = p.TienShip,
		};
		await _shopDbContext.AddAsync(hd);
		await _shopDbContext.SaveChangesAsync();
		return hd.Id;
	}

	public async Task<int> Delete(Guid id)
	{
		var hoaDon = await _shopDbContext.HoaDons.FindAsync(id);
		if (hoaDon == null)
		{
			throw new ShopExeption($"Không thể tìm thấy sản phẩm với : {id}");
		}
		_shopDbContext.HoaDons.Remove(hoaDon);
		return await _shopDbContext.SaveChangesAsync();
	}

	public async Task<Guid> Edit(HoaDonVM p)
	{
		HoaDon hd = await _shopDbContext.HoaDons.FindAsync(p.Id);
		hd.IdKh = p.IdKh;
		hd.IdVoucher = p.IdVoucher;
		hd.Ma = p.Ma;
		hd.NgayNhan = p.NgayNhan;
		hd.NgayShip = p.NgayShip;
		hd.NgayTao = p.NgayTao;
		hd.NgayThanhToan = p.NgayThanhToan;
		hd.TenKh = p.TenKh;
		hd.DiaChi = p.DiaChi;
		hd.TenNguoiShip = p.TenNguoiShip;
		hd.TongTien = p.TongTien;
		hd.SdtNguoiNhan = p.SdtNguoiNhan;
		hd.SdtNguoiShip = p.SdtNguoiShip;
		hd.PhanTramGiamGia = p.PhanTramGiamGia;
		hd.SoDiemSuDung = p.SoDiemSuDung;
		hd.SoTienQuyDoi = p.SoTienQuyDoi;
		hd.TienShip = p.TienShip;
		_shopDbContext.HoaDons.Update(hd);
		await _shopDbContext.SaveChangesAsync();
		return hd.Id;
	}

	public async Task<List<HoaDonVM>> GetAll()
	{
		return await _shopDbContext.HoaDons
				.Select(p => new HoaDonVM()
				{
					Id = p.Id,
					IdKh = p.IdKh,
					IdVoucher = p.IdVoucher,
					Ma = p.Ma,
					NgayNhan = p.NgayNhan,
					NgayShip = p.NgayShip,
					NgayTao = p.NgayTao,
					NgayThanhToan = p.NgayThanhToan,
					TenKh = p.TenKh,
					DiaChi = p.DiaChi,
					TenNguoiShip = p.TenNguoiShip,
					TongTien = p.TongTien,
					SdtNguoiNhan = p.SdtNguoiNhan,
					SdtNguoiShip = p.SdtNguoiShip,
					PhanTramGiamGia = p.PhanTramGiamGia,
					SoDiemSuDung = p.SoDiemSuDung,
					SoTienQuyDoi = p.SoTienQuyDoi,
					TienShip = p.TienShip,
				}
			).ToListAsync();
	}

	public async Task<HoaDonVM> GetById(Guid id)
	{
		HoaDon p = await _shopDbContext.HoaDons.FirstOrDefaultAsync(x => x.Id == id);
		HoaDonVM hoaDonVM = new()
		{
			IdKh = p.IdKh,
			IdVoucher = p.IdVoucher,
			Ma = p.Ma,
			NgayNhan = p.NgayNhan,
			NgayShip = p.NgayShip,
			NgayTao = p.NgayTao,
			NgayThanhToan = p.NgayThanhToan,
			TenKh = p.TenKh,
			DiaChi = p.DiaChi,
			TenNguoiShip = p.TenNguoiShip,
			TongTien = p.TongTien,
			SdtNguoiNhan = p.SdtNguoiNhan,
			SdtNguoiShip = p.SdtNguoiShip,
			PhanTramGiamGia = p.PhanTramGiamGia,
			SoDiemSuDung = p.SoDiemSuDung,
			SoTienQuyDoi = p.SoTienQuyDoi,
			TienShip = p.TienShip,
		};
		return hoaDonVM;
	}
}
