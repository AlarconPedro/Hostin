using Hostin.Core.Entities.Models;
using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces;
using Hostin.Infra.Data.Functions;
using HostIn_Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hostin.Infra.Data.Services;

public class UsuarioService : GenericService<TbUsuario>, IUsuarioService
{
    private readonly HostinContext _context;

    public UsuarioService(HostinContext context) : base(context)
    {
        _context = context;
    }

    public async Task<LoginModel> Login(string usuario, string senha)
    {
        string senhaMD5 = senha.ToMD5();
        string usuarioMD5 = usuario.ToMD5();

        IEnumerable<TbUsuario> retorno =  await GetWithFilter(u => u.UsuEmail == usuario && u.UsuSenha == senhaMD5);
        if (retorno != null)
            return await _context.TbPermissaos
                .Where(p => p.UsuCodigoNavigation.UsuCodigo.Equals(retorno.FirstOrDefault().UsuCodigo))
                    .Select(p => new LoginModel
                    {
                        UsuCodigo = p.UsuCodigoNavigation.UsuCodigo,
                        UsuNome = p.UsuCodigoNavigation.UsuNome,
                        EmpCodigo = p.UsuCodigoNavigation.EmpCodigo,
                        Permissoes = _context.TbPermissaos
                            .Where(per => per.UsuCodigoNavigation.UsuCodigo.Equals(p.UsuCodigoNavigation.UsuCodigo))
                            .Select(per => new PermissoesUsuario
                            {
                                PerAcao = per.PerAcao,
                                PerAdd = per.PerAdd,
                                PerEdit = per.PerEdit,
                                TelCodigo = per.TelCodigo,
                                PerDelete = per.PerDelete,
                            }).ToList(),
                        UsuAdmin = p.UsuCodigoNavigation.UsuAdmin
                    }).FirstOrDefaultAsync();
        else
            return null;

        ////converter a senha para MD5 e comparar com o banco de dados
        //var md5 = System.Security.Cryptography.MD5.Create();
        //var inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
        //var hashBytes = md5.ComputeHash(inputBytes);
        //var retono = GetWithFilter(u => u.UsuEmail == usuario && u.UsuSenha == Convert.ToBase64String(hashBytes));
        //return Task.FromResult(retono);
    }
}
