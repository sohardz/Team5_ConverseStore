using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configuations;
public class GioHangConfiguration : IEntityTypeConfiguration<GioHang>
{
    public void Configure(EntityTypeBuilder<GioHang> builder)
    {
        builder.HasKey(p => p.IdKh);
        builder.Property(p => p.MoTa).HasColumnType("varchar(400)");
    }
}
