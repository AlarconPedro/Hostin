using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Sorteios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Sorteios;

[Route("api/[controller]")]
[ApiController]
public class ParticipantesCuponsController : ControllerBase
{
    private readonly IParticipantesCuponsService _service;

    public ParticipantesCuponsController(IParticipantesCuponsService service)
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
            return NotFound($"Nenhum Cupom Encontrado com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbParticipantesCupon cupom)
    {
        if (cupom == null)
        {
            return BadRequest("Cupom cannot be null.");
        }
        try
        {
            await _service.Add(cupom);
            return CreatedAtAction(nameof(GetById), new { id = cupom.CupCodigo }, cupom);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbParticipantesCupon cupom)
    {
        if (cupom == null)
        {
            return BadRequest("Cupom cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(cupom));
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
            return NotFound($"Nenhum Cupom Encontrado com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
