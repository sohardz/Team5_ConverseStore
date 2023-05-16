using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configuations;
public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
{
    public void Configure(EntityTypeBuilder<KhachHang> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.MaKh).HasColumnType("varchar(50)");
        builder.Property(x => x.HoVaTen).HasColumnType("nvarchar(256)");
        builder.Property(x => x.TenTaiKhoan).HasColumnType("varchar(50)");
        builder.Property(x => x.MatKhau).HasColumnType("varchar(50)");
        builder.Property(x => x.SoDienThoai).HasColumnType("varchar(25)");
        builder.Property(x => x.NgaySinh);
        builder.Property(x => x.DiaChi).HasColumnType("nvarchar(500)");
        builder.Property(x => x.GioiTinh).HasColumnType("int");
        builder.Property(x => x.GhiChu).HasColumnType("nvarchar(500)");
        builder.Property(x => x.SoLanMua).HasColumnType("int");
        builder.Property(x => x.TrangThai).HasColumnType("int");
    }
}
