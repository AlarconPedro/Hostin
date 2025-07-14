using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbCuponsMapping : IEntityTypeConfiguration<TbCupon>
{
    public void Configure(EntityTypeBuilder<TbCupon> builder)
    {
        builder.HasKey(e => e.CupCodigo);

        builder.ToTable("Tb_Cupons");

        builder.Property(e => e.CupNumero).HasMaxLength(50);

        builder.HasOne(d => d.ParCodigoNavigation).WithMany(p => p.TbCupons)
            .HasForeignKey(d => d.ParCodigo)
            .HasConstraintName("FK_Tb_Cupons_Tb_Participantes");

        builder.HasOne(d => d.PrmCodigoNavigation).WithMany(p => p.TbCupons)
            .HasForeignKey(d => d.PrmCodigo)
            .HasConstraintName("FK_Tb_Cupons_Tb_Promocao");
    }
}
