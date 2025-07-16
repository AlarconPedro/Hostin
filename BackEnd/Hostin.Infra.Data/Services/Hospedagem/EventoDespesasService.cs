using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Hospedagem;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services.Hospedagem;

internal class EventoDespesasService : GenericService<TbEventoDespesa>, IEventoDespesasService
{
    public EventoDespesasService(HostinContext context) : base(context)
    {
    }
}
