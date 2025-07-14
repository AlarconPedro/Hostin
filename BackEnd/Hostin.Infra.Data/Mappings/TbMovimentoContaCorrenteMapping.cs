using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbMovimentoContaCorrenteMapping : IEntityTypeConfiguration<TbMovimentoContaCorrente>
{
    public void Configure(EntityTypeBuilder<TbMovimentoContaCorrente> builder)
    {
        builder.HasKey(e => e.MccCodigo).HasName("PK__Tb_Movim__2E1F527388616CFC");

        builder.ToTable("Tb_MovimentoContaCorrente");

        builder.HasIndex(e => e.MccCodigo, "UQ__Tb_Movim__2E1F527280DCA2C6").IsUnique();

        builder.Property(e => e.MccDescricao).HasMaxLength(255);
        builder.Property(e => e.MccDocumento).HasMaxLength(255);
        builder.Property(e => e.MccTipo).HasMaxLength(1);
        builder.Property(e => e.MccValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.CntCodigoNavigation).WithMany(p => p.TbMovimentoContaCorrentes)
            .HasForeignKey(d => d.CntCodigo)
            .HasConstraintName("FK_Tb_MovimentoContaCorrente_Tb_Contas");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbMovimentoContaCorrentes)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_MovimentoContaCorrente_Tb_Empresa");
    }
}
