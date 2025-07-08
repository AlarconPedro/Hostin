using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbEventoDespesa
{
    public int EdpCodigo { get; set; }

    public bool? EdpServico { get; set; }

    public bool? EdpProduto { get; set; }

    public int? EdpQuantidade { get; set; }

    public int? EveCodigo { get; set; }

    public string? EdpTipoDespesa { get; set; }

    public int? SerCodigo { get; set; }

    public int? ProCodigo { get; set; }

    public decimal? EdpValor { get; set; }

    public DateOnly? EdpData { get; set; }

    public virtual TbEvento? EveCodigoNavigation { get; set; }

    public virtual TbProduto? ProCodigoNavigation { get; set; }

    public virtual TbServico? SerCodigoNavigation { get; set; }
}
