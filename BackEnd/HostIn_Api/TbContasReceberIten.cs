using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbContasReceberIten
{
    public int CriCodigo { get; set; }

    public int? CtrCodigo { get; set; }

    public decimal? CriValor { get; set; }

    public decimal? CriDesconto { get; set; }

    public DateOnly? CriDataPagamento { get; set; }

    public virtual TbContasReceber? CtrCodigoNavigation { get; set; }
}
