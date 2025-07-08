using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbCupon
{
    public int CupCodigo { get; set; }

    public string? CupNumero { get; set; }

    public bool? CupSorteado { get; set; }

    public bool? CupVendido { get; set; }

    public int? ParCodigo { get; set; }

    public int? PrmCodigo { get; set; }

    public virtual TbParticipante? ParCodigoNavigation { get; set; }

    public virtual TbPromocao? PrmCodigoNavigation { get; set; }

    public virtual ICollection<TbParticipantesCupon> TbParticipantesCupons { get; set; } = new List<TbParticipantesCupon>();

    public virtual ICollection<TbSorteio> TbSorteios { get; set; } = new List<TbSorteio>();
}
