using Hostin.Core.Entities.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Core.Interfaces;

public interface IEmpresaService : IGenericService<TbEmpresa> 
{
    Task AddEmpresa(TbEmpresa empresa); // Method to add a new company
    Task<TbEmpresa> GetEmpresaExistente(string cnpj);
}
