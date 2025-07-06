using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbModeloContrato
{
    public int MctCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public string? MctNome { get; set; }

    public string? MctConteudo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbContrato> TbContratos { get; set; } = new List<TbContrato>();
}
