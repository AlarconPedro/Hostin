using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbMovimentoEstoqueMapping : IEntityTypeConfiguration<TbMovimentoEstoque>
{
    public void Configure(EntityTypeBuilder<TbMovimentoEstoque> builder)
    {
        builder.HasKey(e => e.MovCodigo).HasName("PK__Tb_Movim__74474D54C575C0C2");

        builder.ToTable("Tb_MovimentoEstoque");

        builder.HasIndex(e => e.MovCodigo, "UQ__Tb_Movim__74474D558B28A6B3").IsUnique();

        builder.Property(e => e.MovObservacao).HasColumnType("text");
        builder.Property(e => e.MovTipo).HasMaxLength(1);

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbMovimentoEstoques)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_MovimentoEstoque_Tb_Empresa");

        builder.HasOne(d => d.ProCodigoNavigation).WithMany(p => p.TbMovimentoEstoques)
            .HasForeignKey(d => d.ProCodigo)
            .HasConstraintName("FK_Tb_MovimentoEstoque_Tb_Produtos");

        builder.HasOne(d => d.UsuCodigoNavigation).WithMany(p => p.TbMovimentoEstoques)
            .HasForeignKey(d => d.UsuCodigo)
            .HasConstraintName("FK_Tb_MovimentoEstoque_Tb_Usuarios");
    }
}
