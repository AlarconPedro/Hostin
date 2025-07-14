using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;

public partial class TbGrupoAcessoPermissao
{
    public int GapCodigo { get; set; }

    public int? PerCodigo { get; set; }

    public int? GraCodigo { get; set; }

    public virtual TbGrupoAcesso? GraCodigoNavigation { get; set; }

    public virtual TbPermissao? PerCodigoNavigation { get; set; }
}
