using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbContasReceberMapping : IEntityTypeConfiguration<TbContasReceber>
{
    public void Configure(EntityTypeBuilder<TbContasReceber> builder)
    {
        builder.HasKey(e => e.CtrCodigo);

        builder.ToTable("Tb_ContasReceber");

        builder.Property(e => e.CtrDescricao).HasColumnType("text");
        builder.Property(e => e.CtrValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContasRecebers)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_ContasReceber_Tb_Empresa");

        builder.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbContasRecebers)
            .HasForeignKey(d => d.PesCodigo)
            .HasConstraintName("FK_Tb_ContasReceber_Tb_Pessoas");

        builder.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbContasRecebers)
            .HasForeignKey(d => d.PlcCodigo)
            .HasConstraintName("FK_Tb_ContasReceber_Tb_PlanoContas");
    }
}
