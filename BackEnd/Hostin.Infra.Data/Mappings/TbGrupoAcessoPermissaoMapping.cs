using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbGrupoAcessoPermissaoMapping : IEntityTypeConfiguration<TbGrupoAcessoPermissao>
{
    public void Configure(EntityTypeBuilder<TbGrupoAcessoPermissao> builder)
    {
        builder.HasKey(e => e.GapCodigo);

        builder.ToTable("Tb_GrupoAcessoPermissao");

        builder.Property(e => e.GapCodigo).ValueGeneratedNever();

        builder.HasOne(d => d.GraCodigoNavigation).WithMany(p => p.TbGrupoAcessoPermissaos)
            .HasForeignKey(d => d.GraCodigo)
            .HasConstraintName("FK_Tb_GrupoAcessoPermissao_Tb_GrupoAcesso");

        builder.HasOne(d => d.PerCodigoNavigation).WithMany(p => p.TbGrupoAcessoPermissaos)
            .HasForeignKey(d => d.PerCodigo)
            .HasConstraintName("FK_Tb_GrupoAcessoPermissao_Tb_Permissao");
    }
}
