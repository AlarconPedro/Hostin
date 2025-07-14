using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbEmpresaMapping : IEntityTypeConfiguration<TbEmpresa>
{
    public void Configure(EntityTypeBuilder<TbEmpresa> builder)
    {
        builder.HasKey(e => e.EmpCodigo);

        builder.ToTable("Tb_Empresa");

        builder.HasIndex(e => e.EmpCodigo, "Tb_Empresa_index_0");

        builder.HasIndex(e => e.EmpCodigo, "UQ__Tb_Empre__22C597B821DA9E26").IsUnique();

        builder.Property(e => e.EmpCidade).HasMaxLength(20);
        builder.Property(e => e.EmpCnpj).HasMaxLength(14);
        builder.Property(e => e.EmpEstado).HasMaxLength(2);
        builder.Property(e => e.EmpNome).HasMaxLength(150);
    }
}
