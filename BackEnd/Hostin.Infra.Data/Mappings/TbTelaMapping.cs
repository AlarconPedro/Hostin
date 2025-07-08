using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbTelaMapping : IEntityTypeConfiguration<TbTela>
{
    public void Configure(EntityTypeBuilder<TbTela> builder)
    {
        builder.HasKey(e => e.TelCodigo).HasName("PK__Tb_Telas__584EE757D8A0AEC6");

        builder.ToTable("Tb_Telas");

        builder.HasIndex(e => e.TelCodigo, "UQ__Tb_Telas__584EE7566E88BF9B").IsUnique();

        builder.Property(e => e.TelNome).HasMaxLength(255);

        builder.HasOne(d => d.ModCodigoNavigation).WithMany(p => p.TbTelas)
            .HasForeignKey(d => d.ModCodigo)
            .HasConstraintName("FK_Tb_Telas_Tb_Modulo");
    }
}
