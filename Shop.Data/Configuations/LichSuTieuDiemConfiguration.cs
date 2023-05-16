using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configuations;
public class LichSuTieuDiemConfiguration : IEntityTypeConfiguration<LichSuTieuDiem>
{
    public void Configure(EntityTypeBuilder<LichSuTieuDiem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.SoDiemDaDung).HasColumnType("int");
        builder.Property(x => x.NgaySuDung);
        builder.Property(x => x.SoDiemCong).HasColumnType("int");
        builder.Property(x => x.TrangThai).HasColumnType("int");
        builder.HasOne(x => x.ViDiem).WithMany(x => x.lichSuTieuDiems).HasForeignKey(x => x.IdViDiem);
        builder.HasOne(x => x.QuyDoiDiem).WithMany(x => x.LichSuTieuDiems).HasForeignKey(x => x.IdQuyDoi);
        builder.HasOne(x => x.HoaDon).WithMany(x => x.LichSuTieuDiems).HasForeignKey(x => x.IdHoaDon);
    }
}
