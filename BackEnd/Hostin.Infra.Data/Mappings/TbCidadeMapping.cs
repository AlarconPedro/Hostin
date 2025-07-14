using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbCidadeMapping : IEntityTypeConfiguration<TbCidade>
{
    public void Configure(EntityTypeBuilder<TbCidade> builder)
    {
        builder.HasKey(e => e.CidCodigo).HasName("PK__Tb_Cidad__F0B95DFFF995A31E");

        builder.ToTable("Tb_Cidades");

        builder.HasIndex(e => e.CidCodigo, "UQ__Tb_Cidad__F0B95DFE17FA4B71").IsUnique();

        builder.Property(e => e.CidNome).HasMaxLength(50);
        builder.Property(e => e.CidUf)
            .HasMaxLength(2)
            .HasColumnName("CidUF");
    }
}
