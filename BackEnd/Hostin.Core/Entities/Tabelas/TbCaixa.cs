using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;

public partial class TbCaixa
{
    public int CaiCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public string? CaiStatus { get; set; }

    public DateTime? CaiDataAbertura { get; set; }

    public DateTime? CaiDataFechamento { get; set; }

    public decimal? CaiSaldoFechamento { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbMovimentoCaixa> TbMovimentoCaixas { get; set; } = new List<TbMovimentoCaixa>();
}
