using Hostin.Core.Entities.Models;
using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TbUsuario>>> GetAllUsuarios()
    {
        var usuarios = await _usuarioService.GetAll();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TbUsuario>> GetUsuarioById(int id)
    {
        var usuario = await _usuarioService.GetById(id);
        if (usuario == null)
        {
            return NotFound($"Nenhum Usuário Encontrado com o Id: {id}");
        }
        return Ok(usuario);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginModel>> Login(LoginRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Usuário e senha são obrigatórios.");
        }
        var loginResult = await _usuarioService.Login(request.Email, request.Password);
        if (loginResult == null)
        {
            return Unauthorized("Usuário ou senha inválidos.");
        }
        return Ok(loginResult);
    }

    [HttpPost]
    public async Task<ActionResult<TbUsuario>> AddUsuario(TbUsuario usuario)
    {
        if (usuario == null)
        {
            return BadRequest("Usuário não pode ser nulo.");
        }
        try
        {
            await _usuarioService.Add(usuario);
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.UsuCodigo }, usuario);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<TbUsuario>> UpdateUsuario(TbUsuario usuario)
    {
        if (usuario == null)
        {
            return BadRequest("Usuário não pode ser nulo.");
        }
        try
        {
            await _usuarioService.Update(usuario);
            return Ok(usuario);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUsuario(int id)
    {
        var usuario = await _usuarioService.Delete(id);
        if (!usuario)
        {
            return NotFound($"Nenhum Usuário encontrado com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
