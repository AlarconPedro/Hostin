﻿using System;
using System.Collections.Generic;

namespace Hostin.Core.Entities.Tabelas;

public partial class TbUsuario
{
    public int UsuCodigo { get; set; }

    public string? UsuNome { get; set; }

    public string? UsuEmail { get; set; }

    public string? UsuSenha { get; set; }

    public string? UsuCodigoFirebase { get; set; }

    public bool? UsuAdmin { get; set; }

    public int? EmpCodigo { get; set; }

    public int? GraCodigo { get; set; }

    public virtual TbEmpresa? EmpCodigoNavigation { get; set; }

    public virtual TbGrupoAcesso? GraCodigoNavigation { get; set; }

    public virtual ICollection<TbCompra> TbCompraAutoriCodigoNavigations { get; set; } = new List<TbCompra>();

    public virtual ICollection<TbCompra> TbCompraSoliciCodigoNavigations { get; set; } = new List<TbCompra>();

    public virtual ICollection<TbMovimentoEstoque> TbMovimentoEstoques { get; set; } = new List<TbMovimentoEstoque>();

    public virtual ICollection<TbPermissao> TbPermissaos { get; set; } = new List<TbPermissao>();

    public virtual ICollection<TbUsuarioModulo> TbUsuarioModulos { get; set; } = new List<TbUsuarioModulo>();
}
