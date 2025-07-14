using Hostin.Core.Entities.Models;
using Hostin.Core.Entities.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Core.Interfaces;

public interface IUsuarioService : IGenericService<TbUsuario>
{
    Task<LoginModel> Login(string usuario, string senha);
}
