using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Hospedagem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Hospedagem;

[Route("api/[controller]")]
[ApiController]
public class ParoquiaController : ControllerBase
{
    private readonly IParoquiaService _service;

    public ParoquiaController(IParoquiaService service)
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
            return NotFound($"Nenhuma Paróquia Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbParoquium paroquia)
    {
        if (paroquia == null)
        {
            return BadRequest("Paróquia cannot be null.");
        }
        try
        {
            await _service.Add(paroquia);
            return CreatedAtAction(nameof(GetById), new { id = paroquia.PrqCodigo }, paroquia);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbParoquium paroquia)
    {
        if (paroquia == null)
        {
            return BadRequest("Paróquia cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(paroquia));
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
            return NotFound($"Nenhuma Paróquia Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
