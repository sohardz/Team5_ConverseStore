using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;

public class GiamGiaConfiguration : IEntityTypeConfiguration<GiamGia>
{
    public void Configure(EntityTypeBuilder<GiamGia> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Ma).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Ten).IsRequired().HasMaxLength(100);
        builder.Property(p => p.NgayBatDau);
        builder.Property(p => p.NgayKetThuc);
        builder.Property(p => p.MucGiamGiaTienMat);
        builder.Property(p => p.MucGiamGiaPhanTram);
        builder.Property(p => p.DieuKienGiamGia);
        builder.Property(p => p.LoaiGiamGia);
    }
}