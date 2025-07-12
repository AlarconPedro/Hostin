using Hostin.Core.Interfaces;
using Hostin.Infra.Data.Functions;
using HostIn.Core.Entities;
using HostIn_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services;

public class UsuarioService : GenericService<TbUsuario>, IUsuarioService
{
    public UsuarioService(HostinContext context) : base(context)
    {
    }

    public async Task Login(string usuario, string senha)
    {
        string senhaMD5 = senha.ToMD5();
        string usuarioMD5 = usuario.ToMD5();

        var retorno =  GetWithFilter(u => u.UsuEmail == usuario && u.UsuSenha == senhaMD5);
        ////converter a senha para MD5 e comparar com o banco de dados
        //var md5 = System.Security.Cryptography.MD5.Create();
        //var inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
        //var hashBytes = md5.ComputeHash(inputBytes);
        //var retono = GetWithFilter(u => u.UsuEmail == usuario && u.UsuSenha == Convert.ToBase64String(hashBytes));
        //return Task.FromResult(retono);
    }
}
