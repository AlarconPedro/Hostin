using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbParticipantesCupon
{
    public int PcpCodigo { get; set; }

    public int? CupCodigo { get; set; }

    public int? ParCodigo { get; set; }

    public virtual TbCupon? CupCodigoNavigation { get; set; }

    public virtual TbParticipante? ParCodigoNavigation { get; set; }
}
