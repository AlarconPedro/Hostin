using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbEventoQuarto
{
    public int EvqCodigo { get; set; }

    public int? EveCodigo { get; set; }

    public int? QuaCodigo { get; set; }

    public virtual TbEvento? EveCodigoNavigation { get; set; }

    public virtual TbQuarto? QuaCodigoNavigation { get; set; }

    public virtual ICollection<TbQuartoPessoa> TbQuartoPessoas { get; set; } = new List<TbQuartoPessoa>();
}
