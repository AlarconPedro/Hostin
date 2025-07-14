using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbHospedeMapping : IEntityTypeConfiguration<TbHospede>
{
    public void Configure(EntityTypeBuilder<TbHospede> builder)
    {
        builder.HasKey(e => e.HosCodigo);

        builder.ToTable("Tb_Hospedes");

        builder.Property(e => e.HosCatequista)
            .HasMaxLength(1)
            .IsFixedLength();
        builder.Property(e => e.HosCpf).HasColumnName("HosCPF");
        builder.Property(e => e.HosGenero).HasMaxLength(1);
        builder.Property(e => e.HosNome).HasMaxLength(100);
        builder.Property(e => e.HosObservacao).HasColumnType("text");
        builder.Property(e => e.HosResponsavel)
            .HasMaxLength(1)
            .IsFixedLength();
        builder.Property(e => e.HosSalmista)
            .HasMaxLength(1)
            .IsFixedLength();
        builder.Property(e => e.HosTelefone).HasMaxLength(13);

        builder.HasOne(d => d.ComCodigoNavigation).WithMany(p => p.TbHospedes)
            .HasForeignKey(d => d.ComCodigo)
            .HasConstraintName("FK_Tb_Hospedes_Tb_Comunidades");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbHospedes)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Hospedes_Tb_Empresa");
    }
}
