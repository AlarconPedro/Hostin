using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbMovimentoCaixa
{
    public int McxCodigo { get; set; }

    public int? CaiCodigo { get; set; }

    public DateTime? McxData { get; set; }

    public decimal? McxValor { get; set; }

    public string? McxDescricao { get; set; }

    public string? McxTipo { get; set; }

    public string? McxFormaPagamento { get; set; }

    public int? McxCodigoMovimento { get; set; }

    public virtual TbCaixa? CaiCodigoNavigation { get; set; }
}
