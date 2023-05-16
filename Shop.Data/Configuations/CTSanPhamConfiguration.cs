﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Configuations;
public class CTSanPhamConfiguration : IEntityTypeConfiguration<CTSanPham>
{
    public void Configure(EntityTypeBuilder<CTSanPham> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(p => p.GiaBan).IsRequired();
        builder.Property(p => p.GiaNhap).IsRequired();
        builder.Property(p => p.SoLuongTon).IsRequired();
        builder.Property(p => p.MoTa).IsRequired().HasMaxLength(400);
        builder.HasOne(x => x.KichCo).WithMany(x => x.CTSanPhams).HasForeignKey(x=>x.IdKichCo);
        builder.HasOne(x => x.MauSac).WithMany(x => x.CTSanPhams).HasForeignKey(x=>x.IdMauSac);
        builder.HasOne(x => x.DanhMuc).WithMany(x => x.CTSanPhams).HasForeignKey(x=>x.IdDanhMuc);
        builder.HasOne(x => x.SanPham).WithMany(x => x.CTSanPhams).HasForeignKey(x=>x.IdSanPham);
        
    
    }
}
