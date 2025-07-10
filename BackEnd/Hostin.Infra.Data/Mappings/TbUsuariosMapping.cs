using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbUsuariosMapping : IEntityTypeConfiguration<TbUsuario>
{
    public void Configure(EntityTypeBuilder<TbUsuario> builder)
    {
        builder.HasKey(e => e.UsuCodigo).HasName("PK__Tb_Usuar__B1AF4B5A8E1EE7B6");

        builder.ToTable("Tb_Usuarios");

        builder.HasIndex(e => e.UsuCodigo, "Tb_Usuarios_index_0");

        builder.HasIndex(e => e.UsuCodigo, "UQ__Tb_Usuar__B1AF4B5B4DA4A5CA").IsUnique();

        builder.Property(e => e.UsuAdmin)
            .HasMaxLength(1)
            .IsFixedLength();
        builder.Property(e => e.UsuCodigoFirebase).HasMaxLength(255);
        builder.Property(e => e.UsuEmail).HasMaxLength(255);
        builder.Property(e => e.UsuNome).HasMaxLength(100);
        builder.Property(e => e.UsuSenha).HasMaxLength(255);

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbUsuarios)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Usuarios_Tb_Empresa");

        builder.HasOne(d => d.GraCodigoNavigation).WithMany(p => p.TbUsuarios)
            .HasForeignKey(d => d.GraCodigo)
            .HasConstraintName("FK_Tb_Usuarios_Tb_GrupoAcesso");
    }
}
