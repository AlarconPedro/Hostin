using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbContasReceberItensMapping : IEntityTypeConfiguration<TbContasReceberIten>
{
    public void Configure(EntityTypeBuilder<TbContasReceberIten> builder)
    {
        builder.HasKey(e => e.CriCodigo);

        builder.ToTable("Tb_ContasReceberItens");

        builder.Property(e => e.CriDesconto).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.CriValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.CtrCodigoNavigation).WithMany(p => p.TbContasReceberItens)
            .HasForeignKey(d => d.CtrCodigo)
            .HasConstraintName("FK_Tb_ContasReceberItens_Tb_ContasReceber");
    }
}
