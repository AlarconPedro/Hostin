using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Hospedagem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Hospedagem;

[Route("api/[controller]")]
[ApiController]
public class ComunidadeController : ControllerBase
{
    private readonly IComunidadeService _service;

    public ComunidadeController(IComunidadeService service)
    {
        _service = service;
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
            return NotFound($"Nenhuma Comunidade Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbComunidade comunidade)
    {
        if (comunidade == null)
        {
            return BadRequest("Comunidade cannot be null.");
        }
        try
        {
            await _service.Add(comunidade);
            return CreatedAtAction(nameof(GetById), new { id = comunidade.ComCodigo }, comunidade);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbComunidade comunidade)
    {
        if (comunidade == null)
        {
            return BadRequest("Comunidade cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(comunidade));
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
            return NotFound($"Nenhuma Comunidade Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
