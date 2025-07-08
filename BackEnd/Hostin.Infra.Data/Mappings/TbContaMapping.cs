using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbContaMapping : IEntityTypeConfiguration<TbConta>
{
    public void Configure(EntityTypeBuilder<TbConta> builder)
    {
        builder.HasKey(e => e.CntCodigo).HasName("PK__Tb_Conta__51AA3241D10C7C5A");

        builder.ToTable("Tb_Contas");

        builder.HasIndex(e => e.CntCodigo, "UQ__Tb_Conta__51AA3240ED817BC9").IsUnique();

        builder.Property(e => e.CntAgencia).HasMaxLength(10);
        builder.Property(e => e.CntAgenciaDigito).HasMaxLength(3);
        builder.Property(e => e.CntConta).HasMaxLength(15);
        builder.Property(e => e.CntContaDigito).HasMaxLength(3);
        builder.Property(e => e.CntNomeAgencia).HasMaxLength(20);
        builder.Property(e => e.CntTipoConta).HasMaxLength(1);
        builder.Property(e => e.CntTitular).HasMaxLength(50);

        builder.HasOne(d => d.BanCodigoNavigation).WithMany(p => p.TbConta)
            .HasForeignKey(d => d.BanCodigo)
            .HasConstraintName("FK_Tb_Contas_Tb_Bancos");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbConta)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Contas_Tb_Empresa");
    }
}
