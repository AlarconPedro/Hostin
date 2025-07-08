using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbPessoasMapping : IEntityTypeConfiguration<TbPessoa>
{
    public void Configure(EntityTypeBuilder<TbPessoa> builder)
    {
        builder.HasKey(e => e.PesCodigo).HasName("PK__Tb_Pesso__7A20C906EA0F96CC");

        builder.ToTable("Tb_Pessoas");

        builder.HasIndex(e => e.PesCodigo, "UQ__Tb_Pesso__7A20C9072507AD36").IsUnique();

        builder.Property(e => e.PesCpfcnpj).HasColumnName("PesCPFCNPJ");
        builder.Property(e => e.PesNome).HasMaxLength(100);

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbPessoas)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Pessoas_Tb_Empresa");
    }
}
