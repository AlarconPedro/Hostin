using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbContasPagar
{
    public int CtpCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public string? CtpDescricao { get; set; }

    public DateOnly? CtpData { get; set; }

    public DateOnly? CtpDataVencimento { get; set; }

    public decimal? CtpValor { get; set; }

    public int? CtpParcela { get; set; }

    public bool? CtpStatus { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbPlanoConta? PlcCodigoNavigation { get; set; }

    public virtual ICollection<TbContasPagarIten> TbContasPagarItens { get; set; } = new List<TbContasPagarIten>();
}
