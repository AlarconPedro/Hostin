using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Estoque;

[Route("api/[controller]")]
[ApiController]
public class ComprasController : ControllerBase
{
    private readonly IComprasService _service;

    public ComprasController(IComprasService comprasService)
    {
        _service = comprasService;
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
            return NotFound($"Nenhuma Compra Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbCompra compra)
    {
        if (compra == null)
        {
            return BadRequest("Compra cannot be null.");
        }
        try
        {
            await _service.Add(compra);
            return CreatedAtAction(nameof(GetById), new { id = compra.ComCodigo }, compra);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbCompra pessoa)
    {
        if (pessoa == null)
        {
            return BadRequest("Compra cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(pessoa));
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
            return NotFound($"Nenhuma Compra Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
