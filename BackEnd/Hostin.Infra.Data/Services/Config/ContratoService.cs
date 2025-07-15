using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services.Config;

public class ContratoService : GenericService<TbContrato>, IContratoService
{
    public ContratoService(HostinContext context) : base(context)
    {
    }
}
