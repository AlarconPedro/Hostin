using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Estoque;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services.Estoque;

internal class ProdutoService : GenericService<TbProduto>, IProdutoService
{
    public ProdutoService(HostinContext context) : base(context)
    {
    }
}
