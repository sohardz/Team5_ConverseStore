using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configuations;
public class VoucherKhachHangConfiguration : IEntityTypeConfiguration<VoucherKhachHang>
{
    public void Configure(EntityTypeBuilder<VoucherKhachHang> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TrangThai).HasColumnType("int");
        builder.HasOne(x => x.KhachHang).WithMany(x => x.VoucherKhachHangs).HasForeignKey(x => x.IdKh);
        builder.HasOne(x => x.Voucher).WithMany(x => x.VoucherKhachHangs).HasForeignKey(x => x.IdVoucher);
    }
}
