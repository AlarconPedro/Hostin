using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbProdutoMapping : IEntityTypeConfiguration<TbProduto>
{
    public void Configure(EntityTypeBuilder<TbProduto> builder)
    {
        builder.HasKey(e => e.ProCodigo).HasName("PK__Tb_Produ__90746C2298EED2D5");

        builder.ToTable("Tb_Produtos");

        builder.HasIndex(e => e.ProCodigo, "UQ__Tb_Produ__90746C2330FBC2EC").IsUnique();

        builder.Property(e => e.ProCodBarras).HasMaxLength(255);
        builder.Property(e => e.ProMedida).HasMaxLength(255);
        builder.Property(e => e.ProNome).HasMaxLength(100);
        builder.Property(e => e.ProObservacao).HasColumnType("text");
        builder.Property(e => e.ProValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.CatCodigoNavigation).WithMany(p => p.TbProdutos)
            .HasForeignKey(d => d.CatCodigo)
            .HasConstraintName("FK_Tb_Produtos_Tb_Categorias");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbProdutos)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Produtos_Tb_Empresa");
    }
}
