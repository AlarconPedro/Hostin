﻿using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbBloco
{
    public int BloCodigo { get; set; }

    public string? BloNome { get; set; }

    public virtual ICollection<TbQuarto> TbQuartos { get; set; } = new List<TbQuarto>();
}
