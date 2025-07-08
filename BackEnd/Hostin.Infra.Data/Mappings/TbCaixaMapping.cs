using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbCaixaMapping : IEntityTypeConfiguration<TbCaixa>
{
    public void Configure(EntityTypeBuilder<TbCaixa> builder)
    {
        builder.HasKey(e => e.CaiCodigo).HasName("PK__Tb_Caixa__D2C1E5D8A1060C55");

        builder.ToTable("Tb_Caixa");

        builder.HasIndex(e => e.CaiCodigo, "UQ__Tb_Caixa__D2C1E5D982A2152D").IsUnique();

        builder.Property(e => e.CaiDataAbertura).HasColumnType("datetime");
        builder.Property(e => e.CaiDataFechamento).HasColumnType("datetime");
        builder.Property(e => e.CaiSaldoFechamento).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.CaiStatus).HasMaxLength(1);

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCaixas)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Caixa_Tb_Empresa");
    }
}
