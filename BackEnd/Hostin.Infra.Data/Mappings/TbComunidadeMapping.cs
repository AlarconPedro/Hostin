using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbComunidadeMapping : IEntityTypeConfiguration<TbComunidade>
{
    public void Configure(EntityTypeBuilder<TbComunidade> builder)
    {
        builder.HasKey(e => e.ComCodigo).HasName("PK__Tb_Comun__F21E98444B3B9463");

        builder.ToTable("Tb_Comunidades");

        builder.HasIndex(e => e.ComCodigo, "UQ__Tb_Comun__F21E98451DAE2F22").IsUnique();

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbComunidades)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Comunidades_Tb_Empresa");

        builder.HasOne(d => d.PrqCodigoNavigation).WithMany(p => p.TbComunidades)
            .HasForeignKey(d => d.PrqCodigo)
            .HasConstraintName("FK_Tb_Comunidades_Tb_Paroquia");
    }
}
