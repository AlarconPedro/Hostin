using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Sorteios;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services.Sorteios;

internal class PremiosService : GenericService<TbPremio>, IPremiosService
{
    public PremiosService(HostinContext context) : base(context)
    {
    }
}
