using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbMovimentoCaixaMapping : IEntityTypeConfiguration<TbMovimentoCaixa>
{
    public void Configure(EntityTypeBuilder<TbMovimentoCaixa> builder)
    {
        builder.HasKey(e => e.McxCodigo).HasName("PK__Tb_Movim__5DD3ACD013E281F4");

        builder.ToTable("Tb_MovimentoCaixa");

        builder.HasIndex(e => e.McxCodigo, "UQ__Tb_Movim__5DD3ACD1C6215B5D").IsUnique();

        builder.Property(e => e.McxData).HasColumnType("datetime");
        builder.Property(e => e.McxDescricao).HasColumnType("text");
        builder.Property(e => e.McxFormaPagamento).HasMaxLength(10);
        builder.Property(e => e.McxTipo).HasMaxLength(1);
        builder.Property(e => e.McxValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.CaiCodigoNavigation).WithMany(p => p.TbMovimentoCaixas)
            .HasForeignKey(d => d.CaiCodigo)
            .HasConstraintName("FK_Tb_MovimentoCaixa_Tb_Caixa");
    }
}
