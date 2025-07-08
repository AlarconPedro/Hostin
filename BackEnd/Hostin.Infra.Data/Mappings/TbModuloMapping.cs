using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbModuloMapping : IEntityTypeConfiguration<TbModulo>
{
    public void Configure(EntityTypeBuilder<TbModulo> builder)
    {
        builder.HasKey(e => e.ModCodigo);

        builder.ToTable("Tb_Modulo");

        builder.Property(e => e.ModNome).HasMaxLength(255);
    }
}
