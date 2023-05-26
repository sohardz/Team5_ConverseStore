using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;

public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
{
    public void Configure(EntityTypeBuilder<NhanVien> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.HoVaTen).HasColumnType("nvarchar(75)");
        builder.Property(x => x.TenTaiKhoan).HasColumnType("varchar(256)");
        builder.Property(x => x.MatKhau).HasColumnType("varchar(256)");
        builder.Property(x => x.Email).HasColumnType("varchar(256)");
        builder.Property(x => x.Anh).HasColumnType("varchar(256)");
        builder.HasOne(p => p.ChucVu).WithMany(p => p.NhanViens).HasForeignKey(p => p.IdCv);
        builder.HasAlternateKey(p => p.TenTaiKhoan);
    }
}