using Hostin.Core.Interfaces;
using HostIn.Core.Entities;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services;

public class UsuarioService : GenericService<TbUsuario>, IUsuarioService
{
    public UsuarioService(HostinContext context) : base(context)
    {
    }
}
