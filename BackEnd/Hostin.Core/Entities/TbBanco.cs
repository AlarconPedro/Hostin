using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;

public partial class TbBanco
{
    public int BanCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? BanNumero { get; set; }

    public string? BanDescricao { get; set; }

    public string? BanLogo { get; set; }

    public string? BanDigito { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbConta> TbConta { get; set; } = new List<TbConta>();
}
