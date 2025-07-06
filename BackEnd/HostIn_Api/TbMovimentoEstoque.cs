using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbMovimentoEstoque
{
    public int MovCodigo { get; set; }

    public int? ProCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? UsuCodigo { get; set; }

    public int? MovQuantidade { get; set; }

    public DateOnly? MovData { get; set; }

    public string? MovTipo { get; set; }

    public string? MovObservacao { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbProduto? ProCodigoNavigation { get; set; }

    public virtual TbUsuario? UsuCodigoNavigation { get; set; }
}
