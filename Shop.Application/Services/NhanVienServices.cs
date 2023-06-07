using Microsoft.EntityFrameworkCore;
using Shop.Application.Exeptions;
using Shop.Application.IServices;
using Shop.Data.Context;
using Shop.Data.Models;
using Shop.ViewModels.ViewModels;

namespace Shop.Application.Services;

public class NhanVienServices : INhanVienServices
{
    private readonly ShopDbContext _shopDbContext;

    public NhanVienServices(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<Guid> Create(NhanVienVM nv)
    {
        NhanVien nhanVien = new()
        {
            Id = Guid.NewGuid(),
            Ma = nv.Ma,
            IdCv = nv.IdCv,
            HoVaTen = nv.HoVaTen,
            TenTaiKhoan = nv.TenTaiKhoan,
            MatKhau = nv.MatKhau,
            Anh = nv.Anh,
            Email = nv.Email,
            TrangThai = nv.TrangThai,
        };
        await _shopDbContext.AddAsync(nhanVien);
         await _shopDbContext.SaveChangesAsync();
        return nhanVien.Id;

    }

    public async Task<int> Delete(Guid id)
    {
        var nhanvien = await _shopDbContext.NhanViens.FindAsync(id);
        if (nhanvien == null)
        {
            throw new ShopExeption($"Không thể tìm thấy nhân viên với Id: {id}");
        }
        _shopDbContext.NhanViens.Remove(nhanvien);
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
                Ma = x.k.Ma,
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
            Ma = chucvu.Ma,
            HoVaTen = chucvu.HoVaTen,
            MatKhau = chucvu.MatKhau,
            Email = chucvu.Email,
            TenTaiKhoan = chucvu.TenTaiKhoan,
            TrangThai = chucvu.TrangThai
        };
        return chucvuviewmodel;
    }

    public async Task<Guid> Edit(NhanVienVM nv)
    {
        var nhanVien = await _shopDbContext.NhanViens.FindAsync(nv.Id);
        if ( nhanVien== null) throw new ShopExeption($"Không thể tim thấy nhân viên với Id:  {nv.Id}");
        nhanVien.IdCv = nv.IdCv;
        nhanVien.Ma = nv.Ma;
        nhanVien.HoVaTen = nv.HoVaTen;
        nhanVien.MatKhau = nv.MatKhau;
        nhanVien.Email = nv.Email;
        nhanVien.Anh = nv.Anh;
        nhanVien.TrangThai = nv.TrangThai;
        await _shopDbContext.SaveChangesAsync();
        return nhanVien.Id;
    }
}
