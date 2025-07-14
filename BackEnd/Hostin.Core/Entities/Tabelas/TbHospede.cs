using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;
public partial class TbHospede
{
    public int HosCodigo { get; set; }

    public string? HosNome { get; set; }

    public string? HosGenero { get; set; }

    public string? HosTelefone { get; set; }

    public int? HosCpf { get; set; }

    public bool? HosStatus { get; set; }

    public int? HosConjugue { get; set; }

    public int? ComCodigo { get; set; }

    public byte[]? HosResponsavel { get; set; }

    public byte[]? HosCatequista { get; set; }

    public byte[]? HosSalmista { get; set; }

    public string? HosObservacao { get; set; }

    public int? EmpCodigo { get; set; }

    public virtual TbComunidade? ComCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }
}
