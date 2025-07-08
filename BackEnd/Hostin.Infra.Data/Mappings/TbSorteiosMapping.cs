using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbSorteiosMapping : IEntityTypeConfiguration<TbSorteio>
{
    public void Configure(EntityTypeBuilder<TbSorteio> builder)
    {
        builder.HasKey(e => e.SorCodigo).HasName("PK__Tb_Sorte__9D26301F41E7A75B");

        builder.ToTable("Tb_Sorteios");

        builder.HasIndex(e => e.SorCodigo, "UQ__Tb_Sorte__9D26301E2CE4F8E8").IsUnique();

        builder.Property(e => e.SorData).HasColumnType("datetime");
        builder.Property(e => e.SorVideo).HasMaxLength(255);

        builder.HasOne(d => d.CupCodigoNavigation).WithMany(p => p.TbSorteios)
            .HasForeignKey(d => d.CupCodigo)
            .HasConstraintName("FK_Tb_Sorteios_Tb_Cupons");

        builder.HasOne(d => d.ParCodigoNavigation).WithMany(p => p.TbSorteios)
            .HasForeignKey(d => d.ParCodigo)
            .HasConstraintName("FK_Tb_Sorteios_Tb_Participantes");

        builder.HasOne(d => d.PreCodigoNavigation).WithMany(p => p.TbSorteios)
            .HasForeignKey(d => d.PreCodigo)
            .HasConstraintName("FK_Tb_Sorteios_Tb_Premios");

        builder.HasOne(d => d.PrmCodigoNavigation).WithMany(p => p.TbSorteios)
            .HasForeignKey(d => d.PrmCodigo)
            .HasConstraintName("FK_Tb_Sorteios_Tb_Promocao");
    }
}
