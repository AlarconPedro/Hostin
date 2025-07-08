using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbBancoMapping : IEntityTypeConfiguration<TbBanco>
{
    public void Configure(EntityTypeBuilder<TbBanco> builder)
    {
        builder.HasKey(e => e.BanCodigo).HasName("PK__Tb_Banco__96A5870E9DBC5B1F");

        builder.ToTable("Tb_Bancos");

        builder.HasIndex(e => e.BanCodigo, "UQ__Tb_Banco__96A5870F145F842F").IsUnique();

        builder.Property(e => e.BanDescricao).HasMaxLength(50);
        builder.Property(e => e.BanDigito).HasMaxLength(2);
        builder.Property(e => e.BanLogo).HasColumnType("text");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbBancos)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Bancos_Tb_Empresa");
    }
}
