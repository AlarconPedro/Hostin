using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbPlanoConta
{
    public int PlcCodigo { get; set; }

    public string? PlcDescricao { get; set; }

    public string? PlcTipo { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbContasPagar> TbContasPagars { get; set; } = new List<TbContasPagar>();

    public virtual ICollection<TbContasReceber> TbContasRecebers { get; set; } = new List<TbContasReceber>();

    public virtual ICollection<TbLancamento> TbLancamentos { get; set; } = new List<TbLancamento>();

    public virtual ICollection<TbMovimentoInvestimento> TbMovimentoInvestimentos { get; set; } = new List<TbMovimentoInvestimento>();
}
