using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbComprasItenMapping : IEntityTypeConfiguration<TbComprasIten>
{
    public void Configure(EntityTypeBuilder<TbComprasIten> builder)
    {
        builder.HasKey(e => e.CmiCodigo).HasName("PK__Tb_Compr__9D6BC121B6CEC669");

        builder.ToTable("Tb_ComprasItens");

        builder.HasIndex(e => e.CmiCodigo, "UQ__Tb_Compr__9D6BC120C42E23E5").IsUnique();

        builder.Property(e => e.CmiValor).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.CmiValorTotal).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.ComCodigoNavigation).WithMany(p => p.TbComprasItens)
            .HasForeignKey(d => d.ComCodigo)
            .HasConstraintName("FK_Tb_ComprasItens_Tb_Compras");

        builder.HasOne(d => d.ProCodigoNavigation).WithMany(p => p.TbComprasItens)
            .HasForeignKey(d => d.ProCodigo)
            .HasConstraintName("FK_Tb_ComprasItens_Tb_Produtos");
    }
}
