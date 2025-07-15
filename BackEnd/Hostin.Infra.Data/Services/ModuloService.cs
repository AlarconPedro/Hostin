using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services;

public class ModuloService : GenericService<TbModulo>, IModuloSevice
{
    public ModuloService(HostinContext context) : base(context)
    {
        // Additional methods specific to TbModulo can be added here if needed
    }
}
