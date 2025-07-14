using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbCategoriaMapping : IEntityTypeConfiguration<TbCategoria>
{
    public void Configure(EntityTypeBuilder<TbCategoria> builder)
    {
        builder.HasKey(e => e.CatCodigo).HasName("PK__Tb_Categ__16498BD9E670855B");

        builder.ToTable("Tb_Categorias");

        builder.HasIndex(e => e.CatCodigo, "UQ__Tb_Categ__16498BD861ED0D0C").IsUnique();

        builder.Property(e => e.CatNome).HasMaxLength(100);

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCategoria)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Categorias_Tb_Empresa");
    }
}
