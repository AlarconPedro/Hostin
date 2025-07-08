using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbParticipante
{
    public int ParCodigo { get; set; }

    public string? ParNome { get; set; }

    public string? ParCpf { get; set; }

    public string? ParFone { get; set; }

    public DateOnly? ParDataNascimento { get; set; }

    public string? ParEndereco { get; set; }

    public string? ParEmail { get; set; }

    public int? CidCodigo { get; set; }

    public virtual TbCidade? CidCodigoNavigation { get; set; }

    public virtual ICollection<TbCupon> TbCupons { get; set; } = new List<TbCupon>();

    public virtual ICollection<TbParticipantesCupon> TbParticipantesCupons { get; set; } = new List<TbParticipantesCupon>();

    public virtual ICollection<TbSorteio> TbSorteios { get; set; } = new List<TbSorteio>();
}
