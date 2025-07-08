using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbEventoPessoaMapping : IEntityTypeConfiguration<TbEventoPessoa>
{
    public void Configure(EntityTypeBuilder<TbEventoPessoa> builder)
    {
        builder.HasKey(e => e.EvpCodigo);

        builder.ToTable("Tb_EventoPessoas");

        builder.HasOne(d => d.EveCodigoNavigation).WithMany(p => p.TbEventoPessoas)
            .HasForeignKey(d => d.EveCodigo)
            .HasConstraintName("FK_Tb_EventoPessoas_Tb_Eventos");

        builder.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbEventoPessoas)
            .HasForeignKey(d => d.PesCodigo)
            .HasConstraintName("FK_Tb_EventoPessoas_Tb_Pessoas");
    }
}
