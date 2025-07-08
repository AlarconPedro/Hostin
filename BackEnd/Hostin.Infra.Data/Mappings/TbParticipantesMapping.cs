using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbParticipantesMapping : IEntityTypeConfiguration<TbParticipante>
{
    public void Configure(EntityTypeBuilder<TbParticipante> builder)
    {
        builder.HasKey(e => e.ParCodigo).HasName("PK__Tb_Parti__1B33EDC700E123AC");

        builder.ToTable("Tb_Participantes");

        builder.HasIndex(e => e.ParCodigo, "UQ__Tb_Parti__1B33EDC60A750313").IsUnique();

        builder.Property(e => e.ParCpf).HasMaxLength(50);
        builder.Property(e => e.ParEmail).HasMaxLength(255);
        builder.Property(e => e.ParEndereco).HasMaxLength(100);
        builder.Property(e => e.ParFone).HasMaxLength(50);
        builder.Property(e => e.ParNome).HasMaxLength(150);

        builder.HasOne(d => d.CidCodigoNavigation).WithMany(p => p.TbParticipantes)
            .HasForeignKey(d => d.CidCodigo)
            .HasConstraintName("FK_Tb_Participantes_Tb_Cidades");
    }
}
