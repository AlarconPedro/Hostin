using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbEventoMapping : IEntityTypeConfiguration<TbEvento>
{
    public void Configure(EntityTypeBuilder<TbEvento> builder)
    {
        builder.HasKey(e => e.EveCodigo);

        builder.ToTable("Tb_Eventos");

        builder.HasIndex(e => e.EveCodigo, "UQ__Tb_Event__0169913174BE3E37").IsUnique();

        builder.Property(e => e.EveDataFim).HasColumnType("datetime");
        builder.Property(e => e.EveDataInicio).HasColumnType("datetime");
        builder.Property(e => e.EveNome).HasMaxLength(100);
        builder.Property(e => e.EveObservacao).HasColumnType("text");
        builder.Property(e => e.EveTipoCobranca).HasMaxLength(1);
        builder.Property(e => e.EveValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbEventos)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Eventos_Tb_Empresa");
    }
}
