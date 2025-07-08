using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbMovimentoContaCorrente
{
    public int MccCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? CntCodigo { get; set; }

    public string? MccDescricao { get; set; }

    public DateOnly? MccData { get; set; }

    public decimal? MccValor { get; set; }

    public string? MccTipo { get; set; }

    public string? MccDocumento { get; set; }

    public virtual TbConta? CntCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }
}
