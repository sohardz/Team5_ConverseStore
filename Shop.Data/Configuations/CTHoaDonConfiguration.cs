﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Configuations;
public class CTHoaDonConfiguration : IEntityTypeConfiguration<CTHoaDon>
{
    public void Configure(EntityTypeBuilder<CTHoaDon> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(p => p.SoLuong).IsRequired();
        builder.Property(p => p.DonGia).IsRequired();
        builder.HasOne(x => x.CTSanPham).WithMany(x => x.CTHoaDons).HasForeignKey(x => x.IdSanPham);


    }
}
