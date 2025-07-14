using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbModeloContratoMapping : IEntityTypeConfiguration<TbModeloContrato>
{
    public void Configure(EntityTypeBuilder<TbModeloContrato> builder)
    {
        builder.HasKey(e => e.MctCodigo);

        builder.ToTable("Tb_ModeloContratos");

        builder.HasIndex(e => e.MctCodigo, "UQ__Tb_Model__40BC36EE556CACA1").IsUnique();

        builder.Property(e => e.MctConteudo).HasColumnType("text");
        builder.Property(e => e.MctNome).HasMaxLength(255);

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbModeloContratos)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_ModeloContratos_Tb_Empresa");
    }
}
