using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbGrupoAcessoMapping : IEntityTypeConfiguration<TbGrupoAcesso>
{
    public void Configure(EntityTypeBuilder<TbGrupoAcesso> builder)
    {
        builder.HasKey(e => e.GraCodigo);

        builder.ToTable("Tb_GrupoAcesso");

        builder.Property(e => e.GraCodigo).ValueGeneratedNever();
        builder.Property(e => e.GraNome)
            .HasMaxLength(100)
            .IsUnicode(false);
    }
}
