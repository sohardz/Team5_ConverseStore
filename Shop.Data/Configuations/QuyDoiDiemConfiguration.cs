using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configuations;
public class QuyDoiDiemConfiguration : IEntityTypeConfiguration<QuyDoiDiem>
{
    public void Configure(EntityTypeBuilder<QuyDoiDiem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TienTieuDiem).HasColumnType("decimal");
        builder.Property(x => x.TienTichDiem).HasColumnType("decimal");
        builder.Property(x => x.TrangThai).HasColumnType("int");
    }
}
