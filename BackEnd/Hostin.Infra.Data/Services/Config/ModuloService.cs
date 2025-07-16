using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services.Config;

public class ModuloService : GenericService<TbModulo>, IModuloService
{
    public ModuloService(HostinContext context) : base(context)
    {
        // Additional methods specific to TbModulo can be added here if needed
    }
}
