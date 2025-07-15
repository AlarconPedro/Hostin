using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TelaController : ControllerBase
{
    private readonly ITelaService _telaService;

    public TelaController(ITelaService telaService)
    {
        _telaService = telaService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllTelas()
    {
        var telas = await _telaService.GetAll();
        return Ok(telas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetTelaById(int id)
    {
        var tela = await _telaService.GetById(id);
        if (tela == null)
        {
            return NotFound($"Nenhuma Tela Encontrada com o Id: {id}");
        }
        return Ok(tela);
    }

    [HttpPost]
    public async Task<ActionResult> AddTela(TbTela tela)
    {
        if (tela == null)
        {
            return BadRequest("Tela cannot be null.");
        }
        try
        {
            await _telaService.Add(tela);
            return CreatedAtAction(nameof(GetTelaById), new { id = tela.TelCodigo }, tela);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateTela(TbTela tela)
    {
        if (tela == null)
        {
            return BadRequest("Tela cannot be null.");
        }
        try
        {
            await _telaService.Update(tela);
            return NoContent(); // 204 No Content for successful update
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTela(int id)
    {
        var deleted = await _telaService.Delete(id);
        if (!deleted)
        {
            return NotFound($"Nenhuma Tela Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
