using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configuations;
public class ViDiemConfiguration : IEntityTypeConfiguration<ViDiem>
{
    public void Configure(EntityTypeBuilder<ViDiem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TongDiem).HasColumnType("int");
        builder.Property(x => x.SoDiemDaDung).HasColumnType("int");
        builder.Property(x => x.SoDiemDaCong).HasColumnType("int");
        builder.Property(x => x.TrangThai).HasColumnType("int");
    }
}
