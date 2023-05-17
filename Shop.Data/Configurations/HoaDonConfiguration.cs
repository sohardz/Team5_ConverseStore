using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;

namespace Shop.Data.Configurations;
public class HoaDonConfiguration : IEntityTypeConfiguration<HoaDon>
{
    public void Configure(EntityTypeBuilder<HoaDon> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.Ma).HasColumnType("varchar(100)");
        builder.Property(x => x.MaNv).HasColumnType("varchar(100)");
        builder.Property(x => x.NgayTao);
        builder.Property(x => x.NgayThanhToan);
        builder.Property(x => x.NgayShip);
        builder.Property(x => x.NgayNhan);
        builder.Property(x => x.TenKh).HasColumnType("nvarchar(256)");
        builder.Property(x => x.SdtNguoiNhan).HasColumnType("varchar(25)");
        builder.Property(x => x.DiaChi).HasColumnType("nvarchar(256)");
        builder.Property(x => x.TongTien);
        builder.Property(x => x.TrangThai);
        builder.Property(x => x.TenNguoiShip).HasColumnType("nvarchar(256)");
        builder.Property(x => x.SdtNguoiShip).HasColumnType("varchar(25)");
        builder.Property(x => x.PhanTramGiamGia);
        builder.Property(x => x.SoDiemSuDung);
        builder.Property(x => x.SoTienQuyDoi);
        builder.Property(x => x.TienShip);
    }
}
