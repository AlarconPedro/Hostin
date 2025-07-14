using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbSorteio
{
    public int SorCodigo { get; set; }

    public DateTime? SorData { get; set; }

    public int? ParCodigo { get; set; }

    public int? PreCodigo { get; set; }

    public int? CupCodigo { get; set; }

    public int? PrmCodigo { get; set; }

    public string? SorVideo { get; set; }

    public virtual TbCupon? CupCodigoNavigation { get; set; }

    public virtual TbParticipante? ParCodigoNavigation { get; set; }

    public virtual TbPremio? PreCodigoNavigation { get; set; }

    public virtual TbPromocao? PrmCodigoNavigation { get; set; }
}
