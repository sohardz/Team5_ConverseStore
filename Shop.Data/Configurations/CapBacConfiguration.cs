using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;

public class CapBacConfiguration : IEntityTypeConfiguration<CapBac>
{
	public void Configure(EntityTypeBuilder<CapBac> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.SoDiemCan).IsRequired();
		builder.Property(x => x.TrangThai).IsRequired();
	}
}