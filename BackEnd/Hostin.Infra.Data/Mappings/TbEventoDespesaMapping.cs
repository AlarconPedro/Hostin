using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbEventoDespesaMapping : IEntityTypeConfiguration<TbEventoDespesa>
{
    public void Configure(EntityTypeBuilder<TbEventoDespesa> builder)
    {
        builder.HasKey(e => e.EdpCodigo).HasName("PK__Tb_Event__EC3B63A5BC4AFD01");

        builder.ToTable("Tb_EventoDespesa");

        builder.HasIndex(e => e.EdpCodigo, "UQ__Tb_Event__EC3B63A4F7896E92").IsUnique();

        builder.Property(e => e.EdpTipoDespesa).HasMaxLength(1);
        builder.Property(e => e.EdpValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.EveCodigoNavigation).WithMany(p => p.TbEventoDespesas)
            .HasForeignKey(d => d.EveCodigo)
            .HasConstraintName("FK_Tb_EventoDespesa_Tb_Eventos");

        builder.HasOne(d => d.ProCodigoNavigation).WithMany(p => p.TbEventoDespesas)
            .HasForeignKey(d => d.ProCodigo)
            .HasConstraintName("FK_Tb_EventoDespesa_Tb_Produtos");

        builder.HasOne(d => d.SerCodigoNavigation).WithMany(p => p.TbEventoDespesas)
            .HasForeignKey(d => d.SerCodigo)
            .HasConstraintName("FK_Tb_EventoDespesa_Tb_Servicos");
    }
}
