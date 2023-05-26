using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;

public class AnhConfiguration : IEntityTypeConfiguration<Anh>
{
    public void Configure(EntityTypeBuilder<Anh> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.DuongDan).HasColumnType("varchar(400)");
        builder.HasOne(x => x.CTSanPham).WithMany(x => x.Anhs).HasForeignKey(x => x.IdCtsp);
    }
}