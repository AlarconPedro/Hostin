using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbParticipantesCuponsMapping : IEntityTypeConfiguration<TbParticipantesCupon>
{
    public void Configure(EntityTypeBuilder<TbParticipantesCupon> builder)
    {
        builder.HasKey(e => e.PcpCodigo).HasName("PK__Tb_Parti__7370AAAF5B3F6BD8");

        builder.ToTable("Tb_ParticipantesCupons");

        builder.HasIndex(e => e.PcpCodigo, "UQ__Tb_Parti__7370AAAE5FDA1B72").IsUnique();

        builder.HasOne(d => d.CupCodigoNavigation).WithMany(p => p.TbParticipantesCupons)
            .HasForeignKey(d => d.CupCodigo)
            .HasConstraintName("FK_Tb_ParticipantesCupons_Tb_Cupons");

        builder.HasOne(d => d.ParCodigoNavigation).WithMany(p => p.TbParticipantesCupons)
            .HasForeignKey(d => d.ParCodigo)
            .HasConstraintName("FK_Tb_ParticipantesCupons_Tb_Participantes");
    }
}
