using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbQuartoMapping : IEntityTypeConfiguration<TbQuarto>
{
    public void Configure(EntityTypeBuilder<TbQuarto> builder)
    {
        builder.HasKey(e => e.QuaCodigo).HasName("PK__Tb_Quart__45BEC70E334A6542");

        builder.ToTable("Tb_Quartos");

        builder.HasIndex(e => e.QuaCodigo, "UQ__Tb_Quart__45BEC70FF5D08AA0").IsUnique();

        builder.Property(e => e.QuaNome).HasMaxLength(50);

        builder.HasOne(d => d.BloCodigoNavigation).WithMany(p => p.TbQuartos)
            .HasForeignKey(d => d.BloCodigo)
            .HasConstraintName("FK_Tb_Quartos_Tb_Blocos");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbQuartos)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Quartos_Tb_Empresa");
    }
}
