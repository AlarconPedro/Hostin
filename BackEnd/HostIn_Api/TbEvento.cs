using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbEvento
{
    public int EveCodigo { get; set; }

    public string? EveNome { get; set; }

    public bool? EveStatus { get; set; }

    public DateTime? EveDataInicio { get; set; }

    public DateTime? EveDataFim { get; set; }

    public decimal? EveValor { get; set; }

    public string? EveTipoCobranca { get; set; }

    public string? EveObservacao { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbEventoDespesa> TbEventoDespesas { get; set; } = new List<TbEventoDespesa>();

    public virtual ICollection<TbEventoPessoa> TbEventoPessoas { get; set; } = new List<TbEventoPessoa>();

    public virtual ICollection<TbEventoQuarto> TbEventoQuartos { get; set; } = new List<TbEventoQuarto>();
}
