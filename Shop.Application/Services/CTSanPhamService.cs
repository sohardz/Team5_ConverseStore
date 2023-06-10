using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class CTSanPhamService : ICTSanPhamService
{
	private readonly ShopDbContext _shopDbContext;

	public CTSanPhamService(ShopDbContext shopDbContext)
	{
		_shopDbContext = shopDbContext;
	}

	public async Task<List<CTSanPhamVM>> GetAll()
	{
		var query = from p in _shopDbContext.CTSanPhams
					join pt in _shopDbContext.SanPhams on p.IdSanPham equals pt.Id
					join m in _shopDbContext.MauSacs on p.IdMauSac equals m.Id
					join k in _shopDbContext.KichCos on p.IdKichCo equals k.Id
					join d in _shopDbContext.DanhMucs on p.IdDanhMuc equals d.Id
					join g in _shopDbContext.GiamGias on p.IdGiamGia equals g.Id
					select new { p, pt, m, k, d, g };
		var data = await query
			.Select(x => new CTSanPhamVM()
			{
				Id = x.p.Id,
				Ma = x.p.Ma,
				GiaBan = x.p.GiaBan,
				GiaNhap = x.p.GiaNhap,
				SoLuongTon = x.p.SoLuongTon,
				MoTa = x.p.MoTa,
				TrangThai = x.p.TrangThai,
				TenDanhMuc = x.d.Ten,
				SoSize = x.k.SoSize,
				MaGiamGia = x.g.Ma,
				TenMauSac = x.m.Ten,
				TenSP = x.pt.Ten,
				IdKichCo = x.p.IdKichCo,
				IdGiamGia = x.p.IdGiamGia,
				IdMauSac = x.p.IdMauSac,
				IdSanPham = x.p.IdSanPham,
				IdDanhMuc = x.p.IdDanhMuc,
				AnhBanDau = x.p.AnhBanDau,
			}
			).ToListAsync();
		return data;
	}

	public async Task<CTSanPhamVM> GetById(Guid ctspId)
	{
		var cTSP = await _shopDbContext.CTSanPhams.FindAsync(ctspId);
		var sanPhamViewModel = new CTSanPhamVM()
		{
			Id = ctspId,
			Ma = cTSP.Ma,
			GiaBan = cTSP.GiaBan,
			GiaNhap = cTSP.GiaNhap,
			MoTa = cTSP.MoTa,
			SoLuongTon = cTSP.SoLuongTon,
			TrangThai = cTSP.TrangThai,
			TenMauSac = _shopDbContext.MauSacs.FirstOrDefault(x => x.Id == cTSP.IdMauSac).Ten,
			TenDanhMuc = _shopDbContext.DanhMucs.FirstOrDefault(x => x.Id == cTSP.IdDanhMuc).Ten,
			MaGiamGia = _shopDbContext.GiamGias.FirstOrDefault(x => x.Id == cTSP.IdGiamGia).Ma,
			TenSP = _shopDbContext.SanPhams.FirstOrDefault(x => x.Id == cTSP.IdSanPham).Ten,
			SoSize = _shopDbContext.KichCos.FirstOrDefault(x => x.Id == cTSP.IdKichCo).SoSize,
			IdDanhMuc = cTSP.IdDanhMuc,
			IdSanPham = cTSP.IdSanPham,
			IdMauSac = cTSP.IdMauSac,
			IdGiamGia = cTSP.IdGiamGia,
			IdKichCo = cTSP.IdKichCo,
		};
		return sanPhamViewModel;
	}

	public async Task<Guid> Edit(CTSanPhamVM p)
	{
		var sanPham = await _shopDbContext.CTSanPhams.FindAsync(p.Id);
		//var capbac = await _shopDbContext.CapBacs.FirstOrDefaultAsync(x => x.Id == kh.IdBac);
		if (sanPham == null) throw new ShopExeption($"Can't find a product with id: {p.Id}");

		sanPham.Ma = p.Ma;
		sanPham.GiaBan = p.GiaBan;
		sanPham.GiaNhap = p.GiaNhap;
		sanPham.SoLuongTon = p.SoLuongTon;
		sanPham.MoTa = p.MoTa;
		sanPham.TrangThai = p.TrangThai;
		sanPham.IdSanPham = p.IdSanPham;
		sanPham.IdMauSac = p.IdMauSac;
		sanPham.IdDanhMuc = p.IdDanhMuc;
		sanPham.IdGiamGia = p.IdGiamGia;
		sanPham.IdKichCo = p.IdKichCo;
		await _shopDbContext.SaveChangesAsync();
		return sanPham.Id;
	}

	public async Task<Guid> Create(CTSanPhamVM p)
	{

		var sanPham = new CTSanPham()
		{
			Id = Guid.NewGuid(),
			Ma = p.Ma,
			GiaBan = p.GiaBan,
			GiaNhap = p.GiaNhap,
			SoLuongTon = p.SoLuongTon,
			MoTa = p.MoTa,
			TrangThai = p.TrangThai,
			IdDanhMuc = p.IdDanhMuc,
			IdGiamGia = p.IdGiamGia,
			IdMauSac = p.IdMauSac,
			IdKichCo = p.IdKichCo,
			IdSanPham = p.IdSanPham,
		};

		await _shopDbContext.CTSanPhams.AddAsync(sanPham);
		await _shopDbContext.SaveChangesAsync();
		return sanPham.Id;
	}

	public async Task<int> Delete(Guid id)
	{
		var sanPham = await _shopDbContext.CTSanPhams.FindAsync(id);
		if (sanPham == null)
		{
			throw new ShopExeption($"Không thể tìm thấy sản phẩm với : {id}");
		}
		_shopDbContext.CTSanPhams.Remove(sanPham);
		return await _shopDbContext.SaveChangesAsync();
	}
}
