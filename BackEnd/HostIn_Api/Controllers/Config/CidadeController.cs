using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class CidadeController : ControllerBase
{
    private readonly ICidadeService _cidadeService;

    public CidadeController(ICidadeService cidadeService)
    {
        _cidadeService = cidadeService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllCidades()
    {
        var cidades = await _cidadeService.GetAll();
        return Ok(cidades);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCidadeById(int id)
    {
        var cidade = await _cidadeService.GetById(id);
        if (cidade == null)
        {
            return NotFound($"Nenhuma Cidade Encontrada com o Id: {id}");
        }
        return Ok(cidade);
    }

    [HttpPost]
    public async Task<ActionResult> AddCidade(TbCidade cidade)
    {
        if (cidade == null)
        {
            return BadRequest("Cidade cannot be null.");
        }
        try
        {
            await _cidadeService.Add(cidade);
            return CreatedAtAction(nameof(GetCidadeById), new { id = cidade.CidCodigo }, cidade);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCidade(TbCidade cidade)
    {
        if (cidade == null)
        {
            return BadRequest("Cidade cannot be null.");
        }
        try
        {
            await _cidadeService.Update(cidade);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCidade(int id)
    {
        try
        {
            await _cidadeService.Delete(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
}
