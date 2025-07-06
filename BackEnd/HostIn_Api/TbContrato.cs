using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbContrato
{
    public int CntCodigo { get; set; }

    public int? PesCodigo { get; set; }

    public int? MctCodigo { get; set; }

    public int? EmpCodigo { get; set; }

    public int? CntNumero { get; set; }

    public DateOnly? CntData { get; set; }

    public DateOnly? CntInicio { get; set; }

    public DateOnly? CntFim { get; set; }

    public decimal? CntValor { get; set; }

    public byte[]? CntArquivo { get; set; }

    public string? CntObservacao { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbModeloContrato? MctCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }
}
