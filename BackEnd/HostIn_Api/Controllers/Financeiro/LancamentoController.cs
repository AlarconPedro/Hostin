using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Financeiro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Financeiro;

[Route("api/[controller]")]
[ApiController]
public class LancamentoController : ControllerBase
{
    private readonly ILancamentosService _service;

    public LancamentoController(ILancamentosService lancamentoService)
    {
        _service = lancamentoService;
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
            return NotFound($"Nenhum Lançamento Encontrado com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbLancamento lancamento)
    {
        if (lancamento == null)
        {
            return BadRequest("Lançamento cannot be null.");
        }
        try
        {
            await _service.Add(lancamento);
            return CreatedAtAction(nameof(GetById), new { id = lancamento.LncCodigo }, lancamento);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbLancamento lancamento)
    {
        if (lancamento == null)
        {
            return BadRequest("Lançamento cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(lancamento));
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
            return NotFound($"Nenhum Lançamento Encontrado com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
