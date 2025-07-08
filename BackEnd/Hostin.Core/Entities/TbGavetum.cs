using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbGavetum
{
    public int GavCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public DateOnly? GavData { get; set; }

    public decimal? GavValor { get; set; }

    public string? GavObservacao { get; set; }

    public string? GavConciliado { get; set; }

    public string? GavTipoMovimento { get; set; }

    public int? GavCodigoMovimento { get; set; }

    public string? GavDescricao { get; set; }

    public string? GavTipo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }
}
