using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Financeiro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Financeiro;

[Route("api/[controller]")]
[ApiController]
public class CaixaController : ControllerBase
{
    private readonly ICaixaService _service;

    public CaixaController(ICaixaService caixaService)
    {
        _service = caixaService;
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
            return NotFound($"Nenhum Caixa Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbCaixa caixa)
    {
        if (caixa == null)
        {
            return BadRequest("Caixa cannot be null.");
        }
        try
        {
            await _service.Add(caixa);
            return CreatedAtAction(nameof(GetById), new { id = caixa.CaiCodigo }, caixa);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbCaixa caixa)
    {
        if (caixa == null)
        {
            return BadRequest("Caixa cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(caixa));
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
            return NotFound($"Nenhum Caixa Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
