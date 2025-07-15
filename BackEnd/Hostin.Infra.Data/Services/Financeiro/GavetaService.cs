using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Financeiro;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services.Financeiro;

internal class GavetaService : GenericService<TbGavetum>, IGavetaService
{
    public GavetaService(HostinContext context) : base(context)
    {
    }
}
