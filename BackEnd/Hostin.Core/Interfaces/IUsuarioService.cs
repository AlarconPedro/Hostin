﻿using HostIn.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Core.Interfaces;

public interface IUsuarioService : IGenericService<TbUsuario>
{
    Task Login(string usuario, string senha);
}
