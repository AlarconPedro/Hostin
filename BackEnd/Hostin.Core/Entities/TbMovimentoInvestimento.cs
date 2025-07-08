using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbMovimentoInvestimento
{
    public int MinCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? CntCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public DateOnly? MinData { get; set; }

    public decimal? MinValor { get; set; }

    public string? MinTipo { get; set; }

    public string? MinTipoMovimento { get; set; }

    public int? MinCodigoMovimento { get; set; }

    public string? MinDescricao { get; set; }

    public string? MinTipoOperacao { get; set; }

    public virtual TbConta? CntCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPlanoConta? PlcCodigoNavigation { get; set; }
}
