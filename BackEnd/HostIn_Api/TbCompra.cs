using System;
using System.Collections.Generic;

namespace HostIn_Api;

public partial class TbCompra
{
    public int ComCodigo { get; set; }

    public int? ComNumero { get; set; }

    public string? ComObservacao { get; set; }

    public int? PesCodigo { get; set; }

    public int? CtpCodigo { get; set; }

    public DateOnly? ComData { get; set; }

    public string? ComStatus { get; set; }

    public int? EmpCodigo { get; set; }

    public DateOnly? ComPrazo { get; set; }

    public int? SoliciCodigo { get; set; }

    public int? AutoriCodigo { get; set; }

    public string? ComJustificativa { get; set; }

    public DateOnly? ComDataExecucao { get; set; }

    public DateOnly? ComAutorizacao { get; set; }

    public byte[]? ComArquivo { get; set; }

    public virtual TbUsuario? AutoriCodigoNavigation { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbPessoa? PesCodigoNavigation { get; set; }

    public virtual TbUsuario? SoliciCodigoNavigation { get; set; }

    public virtual ICollection<TbComprasIten> TbComprasItens { get; set; } = new List<TbComprasIten>();
}
