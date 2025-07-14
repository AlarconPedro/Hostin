using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbGavetaMapping : IEntityTypeConfiguration<TbGavetum>
{
    public void Configure(EntityTypeBuilder<TbGavetum> builder)
    {
        builder.HasKey(e => e.GavCodigo);

        builder.ToTable("Tb_Gaveta");

        builder.Property(e => e.GavConciliado).HasMaxLength(1);
        builder.Property(e => e.GavDescricao).HasMaxLength(255);
        builder.Property(e => e.GavObservacao).HasColumnType("text");
        builder.Property(e => e.GavTipo).HasMaxLength(1);
        builder.Property(e => e.GavTipoMovimento).HasMaxLength(2);
        builder.Property(e => e.GavValor).HasColumnType("numeric(18, 0)");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbGaveta)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Gaveta_Tb_Empresa");
    }
}
