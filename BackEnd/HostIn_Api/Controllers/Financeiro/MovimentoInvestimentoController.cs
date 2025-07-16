using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Financeiro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Financeiro;

[Route("api/[controller]")]
[ApiController]
public class MovimentoInvestimentoController : ControllerBase
{
    private readonly IMovimentoInvestimentoService _service;

    public MovimentoInvestimentoController(IMovimentoInvestimentoService movimentoInvestimentoService)
    {
        _service = movimentoInvestimentoService;
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
            return NotFound($"Nenhum Movimento Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbMovimentoInvestimento movimento)
    {
        if (movimento == null)
        {
            return BadRequest("Movimento cannot be null.");
        }
        try
        {
            await _service.Add(movimento);
            return CreatedAtAction(nameof(GetById), new { id = movimento.MinCodigo }, movimento);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbMovimentoInvestimento movimento)
    {
        if (movimento == null)
        {
            return BadRequest("Movimento cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(movimento));
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
            return NotFound($"Nenhum Movimento Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
