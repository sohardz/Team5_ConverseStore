using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;

public class CTHoaDonConfiguration : IEntityTypeConfiguration<CTHoaDon>
{
    public void Configure(EntityTypeBuilder<CTHoaDon> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.SoLuong).IsRequired();
        builder.Property(p => p.DonGia).IsRequired();
        builder.HasOne(x => x.CTSanPham).WithMany(x => x.CTHoaDons).HasForeignKey(x => x.IdCtsp);
        builder.HasOne(x => x.HoaDon).WithMany(x => x.CTHoaDons).HasForeignKey(x => x.IdHoaDon);
    }
}