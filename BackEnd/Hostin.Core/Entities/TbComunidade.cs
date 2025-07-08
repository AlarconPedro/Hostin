using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;

public partial class TbComunidade
{
    public int ComCodigo { get; set; }

    public int? ComNumero { get; set; }

    public int? PrqCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbParoquium? PrqCodigoNavigation { get; set; }

    public virtual ICollection<TbHospede> TbHospedes { get; set; } = new List<TbHospede>();
}
