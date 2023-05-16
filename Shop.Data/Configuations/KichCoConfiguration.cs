using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Configuations;
public class KichCoConfiguration : IEntityTypeConfiguration<KichCo>
{
    public void Configure(EntityTypeBuilder<KichCo> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(p => p.SoSize).IsRequired().HasColumnType("int");
        
    }
}
