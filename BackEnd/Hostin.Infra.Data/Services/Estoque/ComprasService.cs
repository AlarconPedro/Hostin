using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Estoque;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services.Estoque;

public class ComprasService : GenericService<TbCompra>, IComprasService
{
    public ComprasService(HostinContext context) : base(context)
    {
    }
}
