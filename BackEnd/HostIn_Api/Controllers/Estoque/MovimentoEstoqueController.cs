using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Estoque;

[Route("api/[controller]")]
[ApiController]
public class MovimentoEstoqueController : ControllerBase
{
    private readonly IMovimentoEstoqueService _service;

    public MovimentoEstoqueController(IMovimentoEstoqueService movimentoEstoqueService)
    {
        _service = movimentoEstoqueService;
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
    public async Task<ActionResult> Add(TbMovimentoEstoque movimentoEstoque)
    {
        if (movimentoEstoque == null)
        {
            return BadRequest("Movimento cannot be null.");
        }
        try
        {
            await _service.Add(movimentoEstoque);
            return CreatedAtAction(nameof(GetById), new { id = movimentoEstoque.MovCodigo }, movimentoEstoque);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbMovimentoEstoque pessoa)
    {
        if (pessoa == null)
        {
            return BadRequest("Movimento cannot be null.");
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
            return NotFound($"Nenhum Movimento Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
