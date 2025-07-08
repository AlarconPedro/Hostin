using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbPermissaoMapping : IEntityTypeConfiguration<TbPermissao>
{
    public void Configure(EntityTypeBuilder<TbPermissao> builder)
    {
        builder.HasKey(e => e.PerCodigo).HasName("PK__Tb_Permi__FC98D07E6B3FC69C");

        builder.ToTable("Tb_Permissao");

        builder.HasIndex(e => e.PerCodigo, "UQ__Tb_Permi__FC98D07F6E282091").IsUnique();

        builder.HasOne(d => d.TelCodigoNavigation).WithMany(p => p.TbPermissaos)
            .HasForeignKey(d => d.TelCodigo)
            .HasConstraintName("FK_Tb_Permissao_Tb_Telas");

        builder.HasOne(d => d.UsuCodigoNavigation).WithMany(p => p.TbPermissaos)
            .HasForeignKey(d => d.UsuCodigo)
            .HasConstraintName("FK_Tb_Permissao_Tb_Usuarios");
    }
}
