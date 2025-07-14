using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbProduto
{
    public int ProCodigo { get; set; }

    public string? ProNome { get; set; }

    public string? ProCodBarras { get; set; }

    public string? ProMedida { get; set; }

    public int? ProQuantidade { get; set; }

    public int? CatCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public decimal? ProValor { get; set; }

    public double? ProMargemLucro { get; set; }

    public string? ProObservacao { get; set; }

    public virtual TbCategoria? CatCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbComprasIten> TbComprasItens { get; set; } = new List<TbComprasIten>();

    public virtual ICollection<TbEventoDespesa> TbEventoDespesas { get; set; } = new List<TbEventoDespesa>();

    public virtual ICollection<TbMovimentoEstoque> TbMovimentoEstoques { get; set; } = new List<TbMovimentoEstoque>();
}
