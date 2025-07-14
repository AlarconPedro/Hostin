using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbPromocaoMapping : IEntityTypeConfiguration<TbPromocao>
{
    public void Configure(EntityTypeBuilder<TbPromocao> builder)
    {
        builder.HasKey(e => e.PrmCodigo).HasName("PK__Tb_Promo__7EA915095874ED9F");

        builder.ToTable("Tb_Promocao");

        builder.HasIndex(e => e.PrmCodigo, "UQ__Tb_Promo__7EA915081AF4DEA2").IsUnique();

        builder.Property(e => e.PrmDescricao).HasMaxLength(255);
        builder.Property(e => e.PrmNome).HasMaxLength(150);

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbPromocaos)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Promocao_Tb_Empresa");
    }
}

