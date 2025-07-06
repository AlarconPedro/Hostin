using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbModulo
{
    public int ModCodigo { get; set; }

    public string? ModNome { get; set; }

    public virtual ICollection<TbTela> TbTelas { get; set; } = new List<TbTela>();

    public virtual ICollection<TbUsuarioModulo> TbUsuarioModulos { get; set; } = new List<TbUsuarioModulo>();
}
