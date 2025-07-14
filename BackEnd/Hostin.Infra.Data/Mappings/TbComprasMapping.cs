using Hostin.Core.Entities.Tabelas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Mappings;

internal class TbComprasMapping : IEntityTypeConfiguration<TbCompra>
{
    public void Configure(EntityTypeBuilder<TbCompra> builder)
    {
        builder.HasKey(e => e.ComCodigo).HasName("PK__Tb_Compr__F21E9844CC68ED43");

        builder.ToTable("Tb_Compras");

        builder.HasIndex(e => e.ComCodigo, "UQ__Tb_Compr__F21E984500B541B9").IsUnique();

        builder.Property(e => e.ComArquivo).HasMaxLength(255);
        builder.Property(e => e.ComJustificativa).HasColumnType("text");
        builder.Property(e => e.ComObservacao).HasColumnType("text");
        builder.Property(e => e.ComStatus).HasMaxLength(1);

        builder.HasOne(d => d.AutoriCodigoNavigation).WithMany(p => p.TbCompraAutoriCodigoNavigations)
            .HasForeignKey(d => d.AutoriCodigo)
            .HasConstraintName("FK_Tb_Compras_Autorizador");

        builder.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCompras)
            .HasForeignKey(d => d.EmpCodigo)
            .HasConstraintName("FK_Tb_Compras_Tb_Empresa");

        builder.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbCompras)
            .HasForeignKey(d => d.PesCodigo)
            .HasConstraintName("FK_Tb_Compras_Tb_ContasPagar");

        builder.HasOne(d => d.SoliciCodigoNavigation).WithMany(p => p.TbCompraSoliciCodigoNavigations)
            .HasForeignKey(d => d.SoliciCodigo)
            .HasConstraintName("FK_Tb_Compras_Solicitante");
    }
}
