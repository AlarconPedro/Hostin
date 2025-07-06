using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbTela
{
    public int TelCodigo { get; set; }

    public int? ModCodigo { get; set; }

    public string? TelNome { get; set; }

    public virtual TbModulo? ModCodigoNavigation { get; set; }

    public virtual ICollection<TbPermissao> TbPermissaos { get; set; } = new List<TbPermissao>();
}
