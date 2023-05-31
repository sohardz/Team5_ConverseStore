using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;

public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
{
    public void Configure(EntityTypeBuilder<Voucher> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Ma).HasColumnType("varchar(50)");
        builder.Property(x => x.SoTienCan).HasColumnType("decimal");
        builder.Property(x => x.SoTienGiam).HasColumnType("decimal");
        builder.Property(x => x.NgayApDung);
        builder.Property(x => x.NgayKetThuc);
        builder.Property(x => x.SoLuong).HasColumnType("int");
        builder.Property(x => x.MoTa).HasColumnType("nvarchar(500)");
        builder.Property(x => x.TrangThai).HasColumnType("int");
    }
}