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
    private readonly IUsuarioService _service;
    public UsuarioController(IUsuarioService usuarioService)
    {
        _service = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var retorno = await _service.GetAll();
        return Ok(retorno);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var retorno = await _service.GetById(id);
        if (retorno == null)
        {
            return NotFound($"Nenhum Usuario Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbUsuario usuario)
    {
        if (usuario == null)
        {
            return BadRequest("Usuario cannot be null.");
        }
        try
        {
            await _service.Add(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.UsuCodigo }, usuario);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbUsuario usuario)
    {
        if (usuario == null)
        {
            return BadRequest("Usuario cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(usuario));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var retorno = await _service.Delete(id);
        if (!retorno)
        {
            return NotFound($"Nenhum Usuario Encontrado com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
