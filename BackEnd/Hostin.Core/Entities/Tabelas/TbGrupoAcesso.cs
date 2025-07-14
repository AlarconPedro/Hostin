using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;

public partial class TbGrupoAcesso
{
    public int GraCodigo { get; set; }

    public string? GraNome { get; set; }

    public int? GapCodigo { get; set; }

    public virtual ICollection<TbGrupoAcessoPermissao> TbGrupoAcessoPermissaos { get; set; } = new List<TbGrupoAcessoPermissao>();

    public virtual ICollection<TbUsuario> TbUsuarios { get; set; } = new List<TbUsuario>();
}
