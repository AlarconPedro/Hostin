using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbQuarto
{
    public int QuaCodigo { get; set; }

    public string? QuaNome { get; set; }

    public int? BloCodigo { get; set; }

    public int? QuaQtdCamas { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbBloco? BloCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbEventoQuarto> TbEventoQuartos { get; set; } = new List<TbEventoQuarto>();
}
