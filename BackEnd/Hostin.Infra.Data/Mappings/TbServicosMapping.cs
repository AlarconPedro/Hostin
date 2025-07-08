using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbServicosMapping : IEntityTypeConfiguration<TbServico>
{
    public void Configure(EntityTypeBuilder<TbServico> builder)
    {
        builder.HasKey(e => e.SerCodigo).HasName("PK__Tb_Servi__D1C8C4DA396B717D");

        builder.ToTable("Tb_Servicos");

        builder.HasIndex(e => e.SerCodigo, "UQ__Tb_Servi__D1C8C4DBD5558ACC").IsUnique();

        builder.Property(e => e.SerNome).HasMaxLength(100);

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbServicos)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Servicos_Tb_Empresa");
    }
}
