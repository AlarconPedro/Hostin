using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Hostin.Infra.Data.Services.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class CidadeController : ControllerBase
{
    private readonly ICidadeService _service;

    public CidadeController(ICidadeService cidadeService)
    {
        _service = cidadeService;
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
            return NotFound($"Nenhuma Cidade Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbCidade cidade)
    {
        if (cidade == null)
        {
            return BadRequest("Cidade cannot be null.");
        }
        try
        {
            await _service.Add(cidade);
            return CreatedAtAction(nameof(GetById), new { id = cidade.CidCodigo }, cidade);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbCidade cidade)
    {
        if (cidade == null)
        {
            return BadRequest("Cidade cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(cidade));
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
            return NotFound($"Nenhuma Cidade Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
