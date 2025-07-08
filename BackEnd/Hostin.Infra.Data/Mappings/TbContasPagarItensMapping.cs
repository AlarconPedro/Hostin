using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbContasPagarItensMapping : IEntityTypeConfiguration<TbContasPagarIten>
{
    public void Configure(EntityTypeBuilder<TbContasPagarIten> builder)
    {
        builder.HasKey(e => e.CpiCodigo);

        builder.ToTable("Tb_ContasPagarItens");

        builder.Property(e => e.CpiDesconto).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.CpiValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.CtpCodigoNavigation).WithMany(p => p.TbContasPagarItens)
            .HasForeignKey(d => d.CtpCodigo)
            .HasConstraintName("FK_Tb_ContasPagarItens_Tb_ContasPagar");
    }
}
