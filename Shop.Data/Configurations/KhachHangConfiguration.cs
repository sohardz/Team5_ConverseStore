using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;

public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
{
    public void Configure(EntityTypeBuilder<KhachHang> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Ma).HasColumnType("varchar(50)");
        builder.Property(x => x.HoVaTen).HasColumnType("nvarchar(256)");
        builder.Property(x => x.TenTaiKhoan).HasColumnType("varchar(50)");
        builder.Property(x => x.MatKhau).HasColumnType("varchar(50)");
        builder.Property(x => x.SoDienThoai).HasColumnType("varchar(25)");
        builder.Property(x => x.NgaySinh);
        builder.Property(x => x.DiaChi).HasColumnType("nvarchar(500)");
        builder.Property(x => x.GioiTinh);
        builder.Property(x => x.SoDiem);
        builder.Property(x => x.GhiChu).HasColumnType("nvarchar(500)");
        builder.Property(x => x.TrangThai);
        builder.HasOne(x => x.CapBac).WithMany(x => x.KhachHangs).HasForeignKey(x => x.IdBac);
    }
}