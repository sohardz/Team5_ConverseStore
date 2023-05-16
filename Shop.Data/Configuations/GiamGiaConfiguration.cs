using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Configuations;
public class GiamGiaConfiguration : IEntityTypeConfiguration<GiamGia>
{
    public void Configure(EntityTypeBuilder<GiamGia> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(p => p.Ma).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Ten).IsRequired().HasMaxLength(100);
        builder.Property(p => p.NgayBatDau);
        builder.Property(p => p.NgayKetThuc);
        builder.Property(p => p.MucGiamGiaTienMat);
        builder.Property(p => p.MucGiamGiaPhanTram);
        builder.Property(p => p.DieuKienGiamGia);
        builder.Property(p => p.LoaiGiamGia);

        

        

    }
}
