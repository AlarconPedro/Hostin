using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Hospedagem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Hospedagem;

[Route("api/[controller]")]
[ApiController]
public class QuartoController : ControllerBase
{
    private readonly IQuartoService _service;

    public QuartoController(IQuartoService service)
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
            return NotFound($"Nenhum Quarto Encontrado com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbQuarto quarto)
    {
        if (quarto == null)
        {
            return BadRequest("Quarto cannot be null.");
        }
        try
        {
            await _service.Add(quarto);
            return CreatedAtAction(nameof(GetById), new { id = quarto.QuaCodigo }, quarto);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbQuarto quarto)
    {
        if (quarto == null)
        {
            return BadRequest("Quarto cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(quarto));
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
            return NotFound($"Nenhum Quarto Encontrado com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
