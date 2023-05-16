using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configuations;
public class SPGiamGiaConfiguration : IEntityTypeConfiguration<SanPhamGiamGia>
{
    public void Configure(EntityTypeBuilder<SanPhamGiamGia> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(p => p.DonGia).IsRequired();
        builder.Property(p => p.SoTienConLai).IsRequired();

        builder.HasOne(p => p.CTSanPham).WithMany(p => p.SanPhamGiamGias).HasForeignKey(p => p.IdSanPham);
        builder.HasOne(p => p.GiamGia).WithMany(p => p.SanPhamGiamGias).HasForeignKey(p => p.IdGiamGia);

    }
}
