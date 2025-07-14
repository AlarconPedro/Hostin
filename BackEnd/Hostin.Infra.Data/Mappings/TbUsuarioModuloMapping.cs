using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbUsuarioModuloMapping : IEntityTypeConfiguration<TbUsuarioModulo>
{
    public void Configure(EntityTypeBuilder<TbUsuarioModulo> builder)
    {
        builder.HasKey(e => e.UsmCodigo).HasName("PK__Tb_Usuar__334C89DB41DAD9A0");

        builder.ToTable("Tb_Usuario_Modulo");

        builder.HasIndex(e => e.UsmCodigo, "UQ__Tb_Usuar__334C89DA098E5B58").IsUnique();

        builder.HasOne(d => d.ModCodigoNavigation).WithMany(p => p.TbUsuarioModulos)
            .HasForeignKey(d => d.ModCodigo)
            .HasConstraintName("FK_Tb_Usuario_Modulo_Tb_Modulo");

        builder.HasOne(d => d.UsuCodigoNavigation).WithMany(p => p.TbUsuarioModulos)
            .HasForeignKey(d => d.UsuCodigo)
            .HasConstraintName("FK_Tb_Usuario_Modulo_Tb_Usuarios");
    }
}
