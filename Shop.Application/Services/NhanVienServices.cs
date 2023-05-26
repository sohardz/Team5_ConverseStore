using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.Application.Services;

public class NhanVienServices : INhanVienServices
{
    private readonly ShopDbContext _shopDbContext;

    public NhanVienServices(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<int> Add(NhanVienVM nv)
    {
        NhanVien nhanVien = new()
        {
            IdCv = nv.IdCv,
            HoVaTen = nv.HoVaTen,
            TenTaiKhoan = nv.TenTaiKhoan,
            MatKhau = nv.MatKhau,
            Anh = nv.Anh,
            Email = nv.Email,
            TrangThai = nv.TrangThai,
        };
        await _shopDbContext.AddAsync(nhanVien);
        return await _shopDbContext.SaveChangesAsync();

    }

    public async Task<int> Delete(Guid id)
    {
        NhanVien nv = await _shopDbContext.NhanViens.FindAsync(id);
        _shopDbContext.NhanViens.Remove(nv);
        return await _shopDbContext.SaveChangesAsync();
    }

    public async Task<List<NhanVienVM>> GetAll()
    {
        var query = from k in _shopDbContext.NhanViens
                    join c in _shopDbContext.ChucVus on k.IdCv equals c.Id
                    select new { k, c };
        var data = await query
            .Select(x => new NhanVienVM()
            {
                Id = x.k.Id,
                IdCv = x.k.IdCv,
                HoVaTen = x.k.HoVaTen,
                TenTaiKhoan = x.k.TenTaiKhoan,
                MatKhau = x.k.MatKhau,
                Email = x.k.Email,
                TrangThai = x.k.TrangThai,
                Anh = x.k.Anh,
            }).ToListAsync();
        return data;
    }

    public async Task<NhanVienVM> GetById(Guid id)
    {
        var chucvu = await _shopDbContext.NhanViens.FindAsync(id);
        var chucvuviewmodel = new NhanVienVM()
        {
            Id = chucvu.Id,
            IdCv = chucvu.IdCv,
            HoVaTen = chucvu.HoVaTen,
            MatKhau = chucvu.MatKhau,
            Email = chucvu.Email,
            TenTaiKhoan = chucvu.TenTaiKhoan,
            TrangThai = chucvu.TrangThai
        };
        return chucvuviewmodel;
    }

    public async Task<int> Update(NhanVienVM nv)
    {
        NhanVien vn = await _shopDbContext.NhanViens.FindAsync(nv.Id);
        vn.IdCv = nv.IdCv;
        vn.HoVaTen = nv.HoVaTen;
        vn.MatKhau = nv.MatKhau;
        vn.Email = nv.Email;
        vn.TenTaiKhoan = nv.TenTaiKhoan;
        vn.TrangThai = nv.TrangThai;
        _shopDbContext.Update(nv);
        return await _shopDbContext.SaveChangesAsync();
    }
}
