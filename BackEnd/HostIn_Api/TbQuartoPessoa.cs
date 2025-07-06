using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbQuartoPessoa
{
    public int QupCodigo { get; set; }

    public int? EvpCodigo { get; set; }

    public int? EvqCodigo { get; set; }

    public bool? QupCheckin { get; set; }

    public bool? QupNaoVem { get; set; }

    public bool? QupChave { get; set; }

    public virtual TbEventoPessoa? EvpCodigoNavigation { get; set; }

    public virtual TbEventoQuarto? EvqCodigoNavigation { get; set; }
}
