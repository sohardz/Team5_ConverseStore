using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

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
                GiaBan = x.p.GiaBan,
                GiaNhap = x.p.GiaNhap,
                SoLuongTon = x.p.SoLuongTon,
                MoTa = x.p.MoTa,
                TrangThai = x.p.TrangThai,
                TenDanhMuc = x.d.Ten,
                SoSize = x.k.SoSize,
                MaGiamGia = x.g.Ma,
                TenMauSac = x.m.Ten,
                TenSP = x.pt.Ten
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
            GiaBan = cTSP.GiaBan,
            GiaNhap = cTSP.GiaNhap,
            MoTa = cTSP.MoTa,
            SoLuongTon = cTSP.SoLuongTon,
            TrangThai = cTSP.TrangThai,
            TenMauSac = _shopDbContext.MauSacs.FirstOrDefault(x => x.Id == cTSP.IdMauSac).Ten,
            TenDanhMuc = _shopDbContext.DanhMucs.FirstOrDefault(x => x.Id == cTSP.IdDanhMuc).Ten,
            MaGiamGia = _shopDbContext.GiamGias.FirstOrDefault(x => x.Id == cTSP.IdGiamGia).Ma,
            TenSP = _shopDbContext.SanPhams.FirstOrDefault(x => x.Id == cTSP.IdSanPham).Ten,
            SoSize = _shopDbContext.KichCos.FirstOrDefault(x => x.Id == cTSP.IdKichCo).SoSize
        };
        return sanPhamViewModel;
    }

    public async Task<int> Edit(CTSanPhamVM p)
    {
        var sanPham = await _shopDbContext.CTSanPhams.FindAsync(p.Id);
        //var capbac = await _shopDbContext.CapBacs.FirstOrDefaultAsync(x => x.Id == kh.IdBac);
        if (sanPham == null) throw new ShopExeption($"Can't find a product with id: {p.Id}");
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
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<int> Create(CTSanPhamVM p)
    {

        var sanPham = new CTSanPham()
        {
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
        return await _shopDbContext.SaveChangesAsync();
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
