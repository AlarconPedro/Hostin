using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbServico
{
    public int SerCodigo { get; set; }

    public string? SerNome { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbEventoDespesa> TbEventoDespesas { get; set; } = new List<TbEventoDespesa>();
}
