using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Core.Entities.Models;

public class LoginModel
{
    public int UsuCodigo { get; set; }
    public string? UsuNome { get; set; }
    public bool? UsuAdmin { get; set; }
    public int? EmpCodigo { get; set; }
    public List<PermissoesUsuario>? Permissoes { get; set; }
}
