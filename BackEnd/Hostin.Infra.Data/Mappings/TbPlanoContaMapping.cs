using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbPlanoContaMapping : IEntityTypeConfiguration<TbPlanoConta>
{
    public void Configure(EntityTypeBuilder<TbPlanoConta> builder)
    {
        builder.HasKey(e => e.PlcCodigo).HasName("PK__Tb_Plano__B74A138E8E9C0D2F");

        builder.ToTable("Tb_PlanoContas");

        builder.HasIndex(e => e.PlcCodigo, "UQ__Tb_Plano__B74A138F4688C07D").IsUnique();

        builder.Property(e => e.PlcDescricao).HasMaxLength(255);
        builder.Property(e => e.PlcTipo).HasMaxLength(1);

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbPlanoConta)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_PlanoContas_Tb_Empresa");
    }
}
