using Hostin.Core.Entities.Tabelas;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services.Financeiro;

internal class ContasReceberService : GenericService<TbContasReceber>
{
    public ContasReceberService(HostinContext context) : base(context)
    {
    }
}
