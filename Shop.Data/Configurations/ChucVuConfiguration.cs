using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;
public class ChucVuConfiguration : IEntityTypeConfiguration<ChucVu>
{
    public void Configure(EntityTypeBuilder<ChucVu> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(p => p.Ten).HasColumnType("nvarchar(100)").IsRequired();
    }
}
