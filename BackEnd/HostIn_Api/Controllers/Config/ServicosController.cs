using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class ServicosController : ControllerBase
{
    private readonly IServicosService _service;

    public ServicosController(IServicosService servicoService)
    {
        _service = servicoService;
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
            return NotFound($"Nenhum Serviço Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbServico servico)
    {
        if (servico == null)
        {
            return BadRequest("Serviço cannot be null.");
        }
        try
        {
            await _service.Add(servico);
            return CreatedAtAction(nameof(GetById), new { id = servico.SerCodigo }, servico);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbServico pessoa)
    {
        if (pessoa == null)
        {
            return BadRequest("Serviço cannot be null.");
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
            return NotFound($"Nenhum Serviço Encontrado com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
