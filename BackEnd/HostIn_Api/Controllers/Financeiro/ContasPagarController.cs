using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Financeiro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Financeiro;

[Route("api/[controller]")]
[ApiController]
public class ContasPagarController : ControllerBase
{
    private readonly IContasPagarService _service;

    public ContasPagarController(IContasPagarService contasPagarService)
    {
        _service = contasPagarService;
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
            return NotFound($"Nenhuma Conta Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbContasPagar conta)
    {
        if (conta == null)
        {
            return BadRequest("Conta cannot be null.");
        }
        try
        {
            await _service.Add(conta);
            return CreatedAtAction(nameof(GetById), new { id = conta.CtpCodigo }, conta);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbContasPagar conta)
    {
        if (conta == null)
        {
            return BadRequest("Conta cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(conta));
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
            return NotFound($"Nenhuma Conta Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
