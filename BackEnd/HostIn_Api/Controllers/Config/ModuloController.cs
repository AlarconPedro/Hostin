using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class ModuloController : ControllerBase
{
    private readonly IModuloService _service;
    public ModuloController(IModuloService moduloService)
    {
        _service = moduloService;
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
            return NotFound($"Nenhum Modulo Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbModulo modulo)
    {
        if (modulo == null)
        {
            return BadRequest("Modulo cannot be null.");
        }
        try
        {
            await _service.Add(modulo);
            return CreatedAtAction(nameof(GetById), new { id = modulo.ModCodigo }, modulo);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbModulo modulo)
    {
        if (modulo == null)
        {
            return BadRequest("Modulo cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(modulo));
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
            return NotFound($"Nenhum Modulo Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
