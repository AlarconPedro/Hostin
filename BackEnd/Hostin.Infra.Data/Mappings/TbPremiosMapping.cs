using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbPremiosMapping : IEntityTypeConfiguration<TbPremio>
{
    public void Configure(EntityTypeBuilder<TbPremio> builder)
    {
        builder.HasKey(e => e.PreCodigo).HasName("PK__Tb_Premi__BC7C175E3A0098F8");

        builder.ToTable("Tb_Premios");

        builder.HasIndex(e => e.PreCodigo, "UQ__Tb_Premi__BC7C175FA5122EC6").IsUnique();

        builder.Property(e => e.PreDescricao).HasMaxLength(255);
        builder.Property(e => e.PreNome).HasMaxLength(255);

        builder.HasOne(d => d.PrmCodigoNavigation).WithMany(p => p.TbPremios)
            .HasForeignKey(d => d.PrmCodigo)
            .HasConstraintName("FK_Tb_Premios_Tb_Premios");
    }
}
