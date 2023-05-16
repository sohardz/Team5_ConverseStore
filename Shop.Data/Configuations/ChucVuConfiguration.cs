using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Data.Models;

namespace Shop.Data.Configuations;
public class ChucVuConfiguration : IEntityTypeConfiguration<ChucVu>
{
    public void Configure(EntityTypeBuilder<ChucVu> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Ten).HasColumnType("varchar(100)");
    }
}
