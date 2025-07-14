using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;

public partial class TbPermissao
{
    public int PerCodigo { get; set; }

    public bool? PerAdd { get; set; }

    public bool? PerEdit { get; set; }

    public bool? PerDelete { get; set; }

    public bool? PerAcao { get; set; }

    public int? TelCodigo { get; set; }

    public int? UsuCodigo { get; set; }

    public virtual ICollection<TbGrupoAcessoPermissao> TbGrupoAcessoPermissaos { get; set; } = new List<TbGrupoAcessoPermissao>();

    public virtual TbTela? TelCodigoNavigation { get; set; }

    public virtual TbUsuario? UsuCodigoNavigation { get; set; }
}
