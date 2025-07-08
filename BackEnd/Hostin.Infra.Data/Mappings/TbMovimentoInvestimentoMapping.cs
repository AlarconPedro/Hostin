using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbMovimentoInvestimentoMapping : IEntityTypeConfiguration<TbMovimentoInvestimento>
{
    public void Configure(EntityTypeBuilder<TbMovimentoInvestimento> builder)
    {
        builder.HasKey(e => e.MinCodigo).HasName("PK__Tb_Movim__3A282FAEF81F7689");

        builder.ToTable("Tb_MovimentoInvestimento");

        builder.HasIndex(e => e.MinCodigo, "UQ__Tb_Movim__3A282FAFB7C583BF").IsUnique();

        builder.Property(e => e.MinDescricao).HasMaxLength(255);
        builder.Property(e => e.MinTipo).HasMaxLength(1);
        builder.Property(e => e.MinTipoMovimento).HasMaxLength(2);
        builder.Property(e => e.MinTipoOperacao).HasMaxLength(1);
        builder.Property(e => e.MinValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.CntCodigoNavigation).WithMany(p => p.TbMovimentoInvestimentos)
            .HasForeignKey(d => d.CntCodigo)
            .HasConstraintName("FK_Tb_MovimentoInvestimento_Tb_Contas");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbMovimentoInvestimentos)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_MovimentoInvestimento_Tb_Empresa");

        builder.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbMovimentoInvestimentos)
            .HasForeignKey(d => d.PlcCodigo)
            .HasConstraintName("FK_Tb_MovimentoInvestimento_Tb_PlanoContas");
    }
}
