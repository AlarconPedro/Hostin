using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbLancamento
{
    public int LncCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public bool? LncTipo { get; set; }

    public string? LncDescricao { get; set; }

    public decimal? LncValor { get; set; }

    public bool? LncFaturado { get; set; }

    public string? LncTipoPeriodo { get; set; }

    public DateOnly? LncDataVencimento { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbPlanoConta? PlcCodigoNavigation { get; set; }
}
