using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;
using System.Reflection;

namespace Shop.Data.Context;
public class ShopDbContext : DbContext
{
    public DbSet<Anh> Anhs { get; set; }
    public DbSet<ChucVu> ChucVus { get; set; }
    public DbSet<CapBac> CapBacs { get; set; }
    public DbSet<CTGioHang> CTGioHangs { get; set; }
    public DbSet<CTHoaDon> CTHoaDons { get; set; }
    public DbSet<CTSanPham> CTSanPhams { get; set; }
    public DbSet<DanhMuc> DanhMucs { get; set; }
    public DbSet<GiamGia> GiamGias { get; set; }
    public DbSet<GioHang> GioHangs { get; set; }
    public DbSet<HoaDon> HoaDons { get; set; }
    public DbSet<KhachHang> KhachHangs { get; set; }
    public DbSet<KichCo> KichCos { get; set; }
    public DbSet<MauSac> MauSacs { get; set; }
    public DbSet<NhanVien> NhanViens { get; set; }
    public DbSet<SanPham> SanPhams { get; set; }
    public DbSet<Voucher> Vouchers { get; set; }

    public ShopDbContext()
    {
    }

    public ShopDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.Entity<KhachHang>()
            .HasOne(a => a.GioHang)
            .WithOne(b => b.KhachHang)
            .HasForeignKey<GioHang>(b => b.IdKh);
    }
}
