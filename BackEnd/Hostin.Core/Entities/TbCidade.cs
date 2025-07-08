using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;

public partial class TbCidade
{
    public int CidCodigo { get; set; }

    public string? CidNome { get; set; }

    public string? CidUf { get; set; }

    public virtual ICollection<TbParoquium> TbParoquia { get; set; } = new List<TbParoquium>();

    public virtual ICollection<TbParticipante> TbParticipantes { get; set; } = new List<TbParticipante>();
}
