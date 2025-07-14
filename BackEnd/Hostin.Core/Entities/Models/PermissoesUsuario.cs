using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Core.Entities.Models;

public class PermissoesUsuario
{
    public bool? PerAdd { get; set; }
    public bool? PerEdit { get; set; }
    public bool? PerDelete { get; set; }
    public bool? PerAcao { get; set; }
    public int? TelCodigo { get; set; }
}
