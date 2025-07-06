using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbContasPagarIten
{
    public int CpiCodigo { get; set; }

    public int? CtpCodigo { get; set; }

    public decimal? CpiValor { get; set; }

    public decimal? CpiDesconto { get; set; }

    public DateOnly? CpiDataPagamento { get; set; }

    public virtual TbContasPagar? CtpCodigoNavigation { get; set; }
}
