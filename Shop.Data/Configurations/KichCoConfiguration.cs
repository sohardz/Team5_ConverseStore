using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;

public class KichCoConfiguration : IEntityTypeConfiguration<KichCo>
{
	public void Configure(EntityTypeBuilder<KichCo> builder)
	{
		builder.HasKey(p => p.Id);
		builder.Property(p => p.SoSize).IsRequired().HasColumnType("int");
	}
}