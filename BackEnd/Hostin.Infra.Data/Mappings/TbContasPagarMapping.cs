using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbContasPagarMapping : IEntityTypeConfiguration<TbContasPagar>
{
    public void Configure(EntityTypeBuilder<TbContasPagar> builder)
    {
        builder.HasKey(e => e.CtpCodigo).HasName("PK__Tb_Conta__D06E6BB8DB55A6C2");

        builder.ToTable("Tb_ContasPagar");

        builder.HasIndex(e => e.CtpCodigo, "UQ__Tb_Conta__D06E6BB9CC24BC14").IsUnique();

        builder.Property(e => e.CtpDescricao).HasMaxLength(255);
        builder.Property(e => e.CtpValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContasPagars)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_ContasPagar_Tb_Empresa");

        builder.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbContasPagars)
            .HasForeignKey(d => d.PesCodigo)
            .HasConstraintName("FK_Tb_ContasPagar_Tb_Pessoas");

        builder.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbContasPagars)
            .HasForeignKey(d => d.PlcCodigo)
            .HasConstraintName("FK_Tb_ContasPagar_Tb_PlanoContas");
    }
}
