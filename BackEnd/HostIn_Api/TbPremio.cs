using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbPremio
{
    public int PreCodigo { get; set; }

    public string? PreNome { get; set; }

    public string? PreDescricao { get; set; }

    public int? PrmCodigo { get; set; }

    public virtual TbPromocao? PrmCodigoNavigation { get; set; }

    public virtual ICollection<TbSorteio> TbSorteios { get; set; } = new List<TbSorteio>();
}
