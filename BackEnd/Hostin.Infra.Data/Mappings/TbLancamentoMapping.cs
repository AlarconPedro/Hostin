using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbLancamentoMapping : IEntityTypeConfiguration<TbLancamento>
{
    public void Configure(EntityTypeBuilder<TbLancamento> builder)
    {
        builder.HasKey(e => e.LncCodigo);

        builder.ToTable("Tb_Lancamentos");

        builder.Property(e => e.LncDescricao).HasColumnType("text");
        builder.Property(e => e.LncTipoPeriodo).HasMaxLength(1);
        builder.Property(e => e.LncValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbLancamentos)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Lancamentos_Tb_Empresa");

        builder.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbLancamentos)
            .HasForeignKey(d => d.PesCodigo)
            .HasConstraintName("FK_Tb_Lancamentos_Tb_Pessoas");

        builder.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbLancamentos)
            .HasForeignKey(d => d.PlcCodigo)
            .HasConstraintName("FK_Tb_Lancamentos_Tb_PlanoContas");
    }
}
