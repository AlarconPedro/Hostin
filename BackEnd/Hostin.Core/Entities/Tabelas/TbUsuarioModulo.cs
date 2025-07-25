﻿using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbUsuarioModulo
{
    public int UsmCodigo { get; set; }

    public int? UsuCodigo { get; set; }

    public int? ModCodigo { get; set; }

    public virtual TbModulo? ModCodigoNavigation { get; set; }

    public virtual TbUsuario? UsuCodigoNavigation { get; set; }
}
