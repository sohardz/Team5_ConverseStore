using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configuations;
public class CTGioHangConfiguration : IEntityTypeConfiguration<CTGioHang>
{
    public void Configure(EntityTypeBuilder<CTGioHang> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(p => p.SoLuong).IsRequired().HasColumnType("int");
        builder.HasOne(p => p.GioHang).WithMany(p => p.CTGioHangs).HasForeignKey(p => p.IdKh);
        builder.HasOne(p => p.CTSanPham).WithMany(p => p.CTGioHangs).HasForeignKey(p => p.IdSanPham);
    }
}
