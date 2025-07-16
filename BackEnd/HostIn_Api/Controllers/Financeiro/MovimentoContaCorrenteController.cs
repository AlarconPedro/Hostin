using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Financeiro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Financeiro;

[Route("api/[controller]")]
[ApiController]
public class MovimentoContaCorrenteController : ControllerBase
{
    private readonly IMovimentoContaCorrenteService _service;

    public MovimentoContaCorrenteController(IMovimentoContaCorrenteService movimentoContaCorrenteService)
    {
        _service = movimentoContaCorrenteService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var cidades = await _service.GetAll();
        return Ok(cidades);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var cidade = await _service.GetById(id);
        if (cidade == null)
        {
            return NotFound($"Nenhum Movimento Encontrada com o Id: {id}");
        }
        return Ok(cidade);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbMovimentoContaCorrente movimento)
    {
        if (movimento == null)
        {
            return BadRequest("Movimento cannot be null.");
        }
        try
        {
            await _service.Add(movimento);
            return CreatedAtAction(nameof(GetById), new { id = movimento.MccCodigo }, movimento);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbMovimentoContaCorrente movimento)
    {
        if (movimento == null)
        {
            return BadRequest("Movimento cannot be null.");
        }
        try
        {
            await _service.Update(movimento);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _service.Delete(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
}
