using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbPessoa
{
    public int PesCodigo { get; set; }

    public string? PesNome { get; set; }

    public int? PesCpfcnpj { get; set; }

    public bool? PesFornecedor { get; set; }

    public bool? PesFuncionario { get; set; }

    public bool? PesCliente { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbCompra> TbCompras { get; set; } = new List<TbCompra>();

    public virtual ICollection<TbContasPagar> TbContasPagars { get; set; } = new List<TbContasPagar>();

    public virtual ICollection<TbContasReceber> TbContasRecebers { get; set; } = new List<TbContasReceber>();

    public virtual ICollection<TbContrato> TbContratos { get; set; } = new List<TbContrato>();

    public virtual ICollection<TbEventoPessoa> TbEventoPessoas { get; set; } = new List<TbEventoPessoa>();

    public virtual ICollection<TbLancamento> TbLancamentos { get; set; } = new List<TbLancamento>();
}
