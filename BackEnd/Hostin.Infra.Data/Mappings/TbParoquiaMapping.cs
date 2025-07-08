using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbParoquiaMapping : IEntityTypeConfiguration<TbParoquium>
{
    public void Configure(EntityTypeBuilder<TbParoquium> builder)
    {
        builder.HasKey(e => e.PrqCodigo).HasName("PK__Tb_Paroq__5994DBA798474AF5");

        builder.ToTable("Tb_Paroquia");

        builder.HasIndex(e => e.PrqCodigo, "UQ__Tb_Paroq__5994DBA6E5F241B7").IsUnique();

        builder.Property(e => e.PrqNome).HasMaxLength(100);

        builder.HasOne(d => d.CidCodigoNavigation).WithMany(p => p.TbParoquia)
            .HasForeignKey(d => d.CidCodigo)
            .HasConstraintName("FK_Tb_Paroquia_Tb_Cidades");
    }
}
