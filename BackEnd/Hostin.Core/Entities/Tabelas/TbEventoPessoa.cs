using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbEventoPessoa
{
    public int EvpCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public int? EveCodigo { get; set; }

    public bool? EvpPagante { get; set; }

    public bool? EvpCobrante { get; set; }

    public virtual TbEvento? EveCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual ICollection<TbQuartoPessoa> TbQuartoPessoas { get; set; } = new List<TbQuartoPessoa>();
}
