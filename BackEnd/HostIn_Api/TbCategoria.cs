using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbCategoria
{
    public int CatCodigo { get; set; }

    public string? CatNome { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbProduto> TbProdutos { get; set; } = new List<TbProduto>();
}
