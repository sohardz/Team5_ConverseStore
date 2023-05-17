using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;
public class MauSacConfiguration : IEntityTypeConfiguration<MauSac>
{
    public void Configure(EntityTypeBuilder<MauSac> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(p => p.Ten).IsRequired().HasColumnType("varchar(100)");
    }
}
