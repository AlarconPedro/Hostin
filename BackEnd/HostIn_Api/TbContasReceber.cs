using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbContasReceber
{
    public int CtrCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public int? PlcCodigo { get; set; }

    public string? CtrDescricao { get; set; }

    public DateOnly? CtrData { get; set; }

    public DateOnly? CtrDataVencimento { get; set; }

    public bool? CtrStatus { get; set; }

    public decimal? CtrValor { get; set; }

    public int? CtrParcela { get; set; }

    public bool? CtrSituacao { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbPlanoConta? PlcCodigoNavigation { get; set; }

    public virtual ICollection<TbContasReceberIten> TbContasReceberItens { get; set; } = new List<TbContasReceberIten>();
}
