using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Estoque;

[Route("api/[controller]")]
[ApiController]
public class ComprasItensController : ControllerBase
{
    private readonly IComprasItensService _service;

    public ComprasItensController(IComprasItensService comprasItensService)
    {
        _service = comprasItensService;
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
    public async Task<ActionResult> Add(TbComprasIten compraItens)
    {
        if (compraItens == null)
        {
            return BadRequest("Compra cannot be null.");
        }
        try
        {
            await _service.Add(compraItens);
            return CreatedAtAction(nameof(GetById), new { id = compraItens.ComCodigo }, compraItens);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbComprasIten pessoa)
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
