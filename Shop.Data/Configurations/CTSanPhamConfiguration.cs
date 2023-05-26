using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;

public class CTSanPhamConfiguration : IEntityTypeConfiguration<CTSanPham>
{
    public void Configure(EntityTypeBuilder<CTSanPham> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.GiaBan).IsRequired();
        builder.Property(p => p.GiaNhap).IsRequired();
        builder.Property(p => p.SoLuongTon).IsRequired();
        builder.Property(p => p.MoTa).IsRequired().HasMaxLength(400);
        builder.HasOne(x => x.KichCo).WithMany(x => x.CTSanPhams).HasForeignKey(x => x.IdKichCo);
        builder.HasOne(x => x.MauSac).WithMany(x => x.CTSanPhams).HasForeignKey(x => x.IdMauSac);
        builder.HasOne(x => x.DanhMuc).WithMany(x => x.CTSanPhams).HasForeignKey(x => x.IdDanhMuc);
        builder.HasOne(x => x.SanPham).WithMany(x => x.CTSanPhams).HasForeignKey(x => x.IdCtsp);
        builder.HasOne(x => x.GiamGia).WithMany(x => x.CTSanPhams).HasForeignKey(x => x.IdGiamGia);
    }
}