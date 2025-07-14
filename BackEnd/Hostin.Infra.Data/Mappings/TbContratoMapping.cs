using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbContratoMapping : IEntityTypeConfiguration<TbContrato>
{
    public void Configure(EntityTypeBuilder<TbContrato> builder)
    {
        builder.HasKey(e => e.CntCodigo);

        builder.ToTable("Tb_Contrato");

        builder.Property(e => e.CntArquivo).HasMaxLength(255);
        builder.Property(e => e.CntObservacao).HasColumnType("text");
        builder.Property(e => e.CntValor).HasColumnType("decimal(18, 0)");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContratos)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Contrato_Tb_Empresa");

        builder.HasOne(d => d.MctCodigoNavigation).WithMany(p => p.TbContratos)
            .HasForeignKey(d => d.MctCodigo)
            .HasConstraintName("FK_Tb_Contrato_Tb_ModeloContratos");

        builder.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbContratos)
            .HasForeignKey(d => d.PesCodigo)
            .HasConstraintName("FK_Tb_Contrato_Tb_Pessoas");
    }
}
