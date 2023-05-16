using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configuations;
public class VoucherLogConfiguration : IEntityTypeConfiguration<VoucherLog>
{
    public void Configure(EntityTypeBuilder<VoucherLog> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TienTruocGiamGia).IsRequired();
        builder.Property(x => x.SoTienGiam).IsRequired();
        builder.HasOne(x => x.HoaDon).WithMany(x => x.VoucherLogs).HasForeignKey(x => x.IdHoaDon);
        builder.HasOne(x => x.Voucher).WithMany(x => x.VoucherLogs).HasForeignKey(x => x.IdVoucher);
        builder.Property(x => x.TrangThai).HasColumnType("int");
    }
}
