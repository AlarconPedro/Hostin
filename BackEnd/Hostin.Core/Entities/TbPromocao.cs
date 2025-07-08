using System;
using System.Collections.Generic;

namespace HostIn.Core.Entities;
public partial class TbPromocao
{
    public int PrmCodigo { get; set; }

    public string? PrmNome { get; set; }

    public DateOnly? PrmDataInicio { get; set; }

    public DateOnly? PrmDataFim { get; set; }

    public string? PrmDescricao { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual ICollection<TbCupon> TbCupons { get; set; } = new List<TbCupon>();

    public virtual ICollection<TbPremio> TbPremios { get; set; } = new List<TbPremio>();

    public virtual ICollection<TbSorteio> TbSorteios { get; set; } = new List<TbSorteio>();
}
