using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbConta
{
    public int CntCodigo { get; set; }

    public int? BanCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public string? CntAgencia { get; set; }

    public string? CntNomeAgencia { get; set; }

    public string? CntConta { get; set; }

    public string? CntTitular { get; set; }

    public string? CntAgenciaDigito { get; set; }

    public string? CntContaDigito { get; set; }

    public string? CntTipoConta { get; set; }

    public bool? CntAtiva { get; set; }

    public virtual TbBanco? BanCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbMovimentoContaCorrente> TbMovimentoContaCorrentes { get; set; } = new List<TbMovimentoContaCorrente>();

    public virtual ICollection<TbMovimentoInvestimento> TbMovimentoInvestimentos { get; set; } = new List<TbMovimentoInvestimento>();
}
