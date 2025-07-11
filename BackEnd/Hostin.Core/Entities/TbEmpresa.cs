using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbEmpresa
{
    public int EmpCodigo { get; set; }

    public string? EmpNome { get; set; }

    public string? EmpCnpj { get; set; }

    public string? EmpCidade { get; set; }

    public string? EmpEstado { get; set; }

    public virtual ICollection<TbBanco> TbBancos { get; set; } = new List<TbBanco>();

    public virtual ICollection<TbCaixa> TbCaixas { get; set; } = new List<TbCaixa>();

    public virtual ICollection<TbCategoria> TbCategoria { get; set; } = new List<TbCategoria>();

    public virtual ICollection<TbCompra> TbCompras { get; set; } = new List<TbCompra>();

    public virtual ICollection<TbComunidade> TbComunidades { get; set; } = new List<TbComunidade>();

    public virtual ICollection<TbConta> TbConta { get; set; } = new List<TbConta>();

    public virtual ICollection<TbContasPagar> TbContasPagars { get; set; } = new List<TbContasPagar>();

    public virtual ICollection<TbContasReceber> TbContasRecebers { get; set; } = new List<TbContasReceber>();

    public virtual ICollection<TbContrato> TbContratos { get; set; } = new List<TbContrato>();

    public virtual ICollection<TbEvento> TbEventos { get; set; } = new List<TbEvento>();

    public virtual ICollection<TbGavetum> TbGaveta { get; set; } = new List<TbGavetum>();

    public virtual ICollection<TbHospede> TbHospedes { get; set; } = new List<TbHospede>();

    public virtual ICollection<TbLancamento> TbLancamentos { get; set; } = new List<TbLancamento>();

    public virtual ICollection<TbModeloContrato> TbModeloContratos { get; set; } = new List<TbModeloContrato>();

    public virtual ICollection<TbMovimentoContaCorrente> TbMovimentoContaCorrentes { get; set; } = new List<TbMovimentoContaCorrente>();

    public virtual ICollection<TbMovimentoEstoque> TbMovimentoEstoques { get; set; } = new List<TbMovimentoEstoque>();

    public virtual ICollection<TbMovimentoInvestimento> TbMovimentoInvestimentos { get; set; } = new List<TbMovimentoInvestimento>();

    public virtual ICollection<TbPessoa> TbPessoas { get; set; } = new List<TbPessoa>();

    public virtual ICollection<TbPlanoConta> TbPlanoConta { get; set; } = new List<TbPlanoConta>();

    public virtual ICollection<TbProduto> TbProdutos { get; set; } = new List<TbProduto>();

    public virtual ICollection<TbPromocao> TbPromocaos { get; set; } = new List<TbPromocao>();

    public virtual ICollection<TbQuarto> TbQuartos { get; set; } = new List<TbQuarto>();

    public virtual ICollection<TbServico> TbServicos { get; set; } = new List<TbServico>();

    public virtual ICollection<TbUsuario> TbUsuarios { get; set; } = new List<TbUsuario>();
}
