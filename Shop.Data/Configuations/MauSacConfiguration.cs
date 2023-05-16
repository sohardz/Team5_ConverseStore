using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Configuations;
public class MauSacConfiguration : IEntityTypeConfiguration<MauSac>
{
    public void Configure(EntityTypeBuilder<MauSac> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(p => p.Ten).IsRequired().HasColumnType("varchar(100)");



    }
}
