using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbParoquium
{
    public int PrqCodigo { get; set; }

    public string? PrqNome { get; set; }

    public int? CidCodigo { get; set; }

    public virtual TbCidade? CidCodigoNavigation { get; set; }

    public virtual ICollection<TbComunidade> TbComunidades { get; set; } = new List<TbComunidade>();
}
