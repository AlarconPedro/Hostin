using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbQuartoPessoaMapping : IEntityTypeConfiguration<TbQuartoPessoa>
{
    public void Configure(EntityTypeBuilder<TbQuartoPessoa> builder)
    {
        builder.HasKey(e => e.QupCodigo).HasName("PK__Tb_Quart__4F44D6A3655FAF5C");

        builder.ToTable("Tb_QuartoPessoa");

        builder.HasIndex(e => e.QupCodigo, "UQ__Tb_Quart__4F44D6A2BB61534E").IsUnique();

        builder.HasOne(d => d.EvpCodigoNavigation).WithMany(p => p.TbQuartoPessoas)
            .HasForeignKey(d => d.EvpCodigo)
            .HasConstraintName("FK_Tb_QuartoPessoa_Tb_EventoPessoas");

        builder.HasOne(d => d.EvqCodigoNavigation).WithMany(p => p.TbQuartoPessoas)
            .HasForeignKey(d => d.EvqCodigo)
            .HasConstraintName("FK_Tb_QuartoPessoa_Tb_EventoQuartos");
    }
}
