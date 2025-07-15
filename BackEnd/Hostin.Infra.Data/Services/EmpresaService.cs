using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services;

public class EmpresaService : GenericService<TbEmpresa>, IEmpresaService
{
    public EmpresaService(HostinContext context) : base(context)
    {
    }

    // Additional methods specific to TbEmpresa can be added here if needed
    // For example, methods to filter or search for companies based on specific criteria
    public async Task AddEmpresa(TbEmpresa empresa)
    {
        TbEmpresa existingEmpresa = await GetEmpresaExistente(empresa.EmpCnpj ?? "");
        if (existingEmpresa != null)
            throw new InvalidOperationException("Empresa with this CNPJ already exists.");
        else
            await Add(empresa);

    }

    public async Task<TbEmpresa> GetEmpresaExistente(string cnpj)
    {
        IEnumerable<TbEmpresa> empresa = await GetWithFilter(e => e.EmpCnpj == cnpj);
        if (empresa != null)
            return empresa.FirstOrDefault();
        else
            return null;
    }
}
