using System;
using System.Collections.Generic;
using Hostin.Infra.Data.Mappings;
using HostIn.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HostIn_Api;

public partial class HostinContext : DbContext
{
    public HostinContext()
    {
    }

    public HostinContext(DbContextOptions<HostinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbBanco> TbBancos { get; set; }

    public virtual DbSet<TbBloco> TbBlocos { get; set; }

    public virtual DbSet<TbCaixa> TbCaixas { get; set; }

    public virtual DbSet<TbCategoria> TbCategorias { get; set; }

    public virtual DbSet<TbCidade> TbCidades { get; set; }

    public virtual DbSet<TbCompra> TbCompras { get; set; }

    public virtual DbSet<TbComprasIten> TbComprasItens { get; set; }

    public virtual DbSet<TbComunidade> TbComunidades { get; set; }

    public virtual DbSet<TbConta> TbContas { get; set; }

    public virtual DbSet<TbContasPagar> TbContasPagars { get; set; }

    public virtual DbSet<TbContasPagarIten> TbContasPagarItens { get; set; }

    public virtual DbSet<TbContasReceber> TbContasRecebers { get; set; }

    public virtual DbSet<TbContasReceberIten> TbContasReceberItens { get; set; }

    public virtual DbSet<TbContrato> TbContratos { get; set; }

    public virtual DbSet<TbCupon> TbCupons { get; set; }

    public virtual DbSet<TbEmpresa> TbEmpresas { get; set; }

    public virtual DbSet<TbEvento> TbEventos { get; set; }

    public virtual DbSet<TbEventoDespesa> TbEventoDespesas { get; set; }

    public virtual DbSet<TbEventoPessoa> TbEventoPessoas { get; set; }

    public virtual DbSet<TbEventoQuarto> TbEventoQuartos { get; set; }

    public virtual DbSet<TbGavetum> TbGaveta { get; set; }

    public virtual DbSet<TbHospede> TbHospedes { get; set; }

    public virtual DbSet<TbLancamento> TbLancamentos { get; set; }

    public virtual DbSet<TbModeloContrato> TbModeloContratos { get; set; }

    public virtual DbSet<TbModulo> TbModulos { get; set; }

    public virtual DbSet<TbMovimentoCaixa> TbMovimentoCaixas { get; set; }

    public virtual DbSet<TbMovimentoContaCorrente> TbMovimentoContaCorrentes { get; set; }

    public virtual DbSet<TbMovimentoEstoque> TbMovimentoEstoques { get; set; }

    public virtual DbSet<TbMovimentoInvestimento> TbMovimentoInvestimentos { get; set; }

    public virtual DbSet<TbParoquium> TbParoquia { get; set; }

    public virtual DbSet<TbParticipante> TbParticipantes { get; set; }

    public virtual DbSet<TbParticipantesCupon> TbParticipantesCupons { get; set; }

    public virtual DbSet<TbPermissao> TbPermissaos { get; set; }

    public virtual DbSet<TbPessoa> TbPessoas { get; set; }

    public virtual DbSet<TbPlanoConta> TbPlanoContas { get; set; }

    public virtual DbSet<TbPremio> TbPremios { get; set; }

    public virtual DbSet<TbProduto> TbProdutos { get; set; }

    public virtual DbSet<TbPromocao> TbPromocaos { get; set; }

    public virtual DbSet<TbQuarto> TbQuartos { get; set; }

    public virtual DbSet<TbQuartoPessoa> TbQuartoPessoas { get; set; }

    public virtual DbSet<TbServico> TbServicos { get; set; }

    public virtual DbSet<TbSorteio> TbSorteios { get; set; }

    public virtual DbSet<TbTela> TbTelas { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<TbUsuarioModulo> TbUsuarioModulos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");

        modelBuilder.ApplyConfiguration(new TbBancoMapping());
        modelBuilder.ApplyConfiguration(new TbBlocoMapping());
        modelBuilder.ApplyConfiguration(new TbCaixaMapping());
        modelBuilder.ApplyConfiguration(new TbCategoriaMapping());
        modelBuilder.ApplyConfiguration(new TbCidadeMapping());
        modelBuilder.ApplyConfiguration(new TbComprasMapping());
        modelBuilder.ApplyConfiguration(new TbComprasItenMapping());
        modelBuilder.ApplyConfiguration(new TbComunidadeMapping());
        modelBuilder.ApplyConfiguration(new TbContaMapping());
        modelBuilder.ApplyConfiguration(new TbContasPagarMapping());
        modelBuilder.ApplyConfiguration(new TbContasPagarItensMapping());
        modelBuilder.ApplyConfiguration(new TbContasReceberMapping());
        modelBuilder.ApplyConfiguration(new TbContasReceberItensMapping());
        modelBuilder.ApplyConfiguration(new TbContratoMapping());
        modelBuilder.ApplyConfiguration(new TbCuponsMapping());
        modelBuilder.ApplyConfiguration(new TbEmpresaMapping());
        modelBuilder.ApplyConfiguration(new TbEventoMapping());
        modelBuilder.ApplyConfiguration(new TbEventoDespesaMapping());
        modelBuilder.ApplyConfiguration(new TbEventoPessoaMapping());
        modelBuilder.ApplyConfiguration(new TbEventoQuartoMapping());
        modelBuilder.ApplyConfiguration(new TbGavetaMapping());
        modelBuilder.ApplyConfiguration(new TbHospedeMapping());
        modelBuilder.ApplyConfiguration(new TbModeloContratoMapping());
        modelBuilder.ApplyConfiguration(new TbModuloMapping());
        modelBuilder.ApplyConfiguration(new TbMovimentoCaixaMapping());
        modelBuilder.ApplyConfiguration(new TbMovimentoContaCorrenteMapping());
        modelBuilder.ApplyConfiguration(new TbMovimentoEstoqueMapping());
        modelBuilder.ApplyConfiguration(new TbMovimentoInvestimentoMapping());
        modelBuilder.ApplyConfiguration(new TbParoquiaMapping());
        modelBuilder.ApplyConfiguration(new TbParticipantesMapping());
        modelBuilder.ApplyConfiguration(new TbParticipantesCuponsMapping());
        modelBuilder.ApplyConfiguration(new TbPermissaoMapping());
        modelBuilder.ApplyConfiguration(new TbPessoasMapping());
        modelBuilder.ApplyConfiguration(new TbPlanoContaMapping());
        modelBuilder.ApplyConfiguration(new TbPremiosMapping());
        modelBuilder.ApplyConfiguration(new TbProdutoMapping());
        modelBuilder.ApplyConfiguration(new TbPromocaoMapping());
        modelBuilder.ApplyConfiguration(new TbQuartoMapping());
        modelBuilder.ApplyConfiguration(new TbQuartoPessoaMapping());
        modelBuilder.ApplyConfiguration(new TbServicosMapping());
        modelBuilder.ApplyConfiguration(new TbSorteiosMapping());
        modelBuilder.ApplyConfiguration(new TbTelaMapping());
        modelBuilder.ApplyConfiguration(new TbUsuariosMapping());
        modelBuilder.ApplyConfiguration(new TbUsuarioModuloMapping());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
