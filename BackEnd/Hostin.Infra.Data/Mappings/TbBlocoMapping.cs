using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbBlocoMapping : IEntityTypeConfiguration<TbBloco>
{
    public void Configure(EntityTypeBuilder<TbBloco> builder)
    {
        builder.HasKey(e => e.BloCodigo).HasName("PK__Tb_Bloco__9CBD088008A994ED");

        builder.ToTable("Tb_Blocos");

        builder.HasIndex(e => e.BloCodigo, "UQ__Tb_Bloco__9CBD08819256E180").IsUnique();

        builder.Property(e => e.BloNome).HasMaxLength(100);
    }
}
