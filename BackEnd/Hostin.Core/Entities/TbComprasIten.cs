﻿using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;

public partial class TbComprasIten
{
    public int CmiCodigo { get; set; }

    public int? ComCodigo { get; set; }

    public int? ProCodigo { get; set; }

    public decimal? CmiValor { get; set; }

    public double? CmiQuantidade { get; set; }

    public decimal? CmiValorTotal { get; set; }

    public virtual TbCompra? ComCodigoNavigation { get; set; }

    public virtual TbProduto? ProCodigoNavigation { get; set; }
}
