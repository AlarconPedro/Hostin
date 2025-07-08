using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbEventoQuartoMapping : IEntityTypeConfiguration<TbEventoQuarto>
{
    public void Configure(EntityTypeBuilder<TbEventoQuarto> builder)
    {
        builder.HasKey(e => e.EvqCodigo).HasName("PK__Tb_Event__FB1F98932DE385D6");

        builder.ToTable("Tb_EventoQuartos");

        builder.HasOne(d => d.EveCodigoNavigation).WithMany(p => p.TbEventoQuartos)
            .HasForeignKey(d => d.EveCodigo)
            .HasConstraintName("FK_Tb_EventoQuartos_Tb_Eventos");

        builder.HasOne(d => d.QuaCodigoNavigation).WithMany(p => p.TbEventoQuartos)
            .HasForeignKey(d => d.QuaCodigo)
            .HasConstraintName("FK_Tb_EventoQuartos_Tb_Quartos");
    }
}
