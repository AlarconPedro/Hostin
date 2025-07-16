using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class ServicosController : ControllerBase
{
    private readonly IGenericService<TbServico> _servicoService;

    public ServicosController(IGenericService<TbServico> servicoService)
    {
        _servicoService = servicoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllServicos()
    {
        var servicos = await _servicoService.GetAll();
        return Ok(servicos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetServicoById(int id)
    {
        var servico = await _servicoService.GetById(id);
        if (servico == null)
        {
            return NotFound();
        }
        return Ok(servico);
    }

    [HttpPost]
    public async Task<IActionResult> CreateServico([FromBody] TbServico servico)
    {
        if (servico == null)
        {
            return BadRequest("Serviço não pode ser nulo.");
        }
        var createdServico = await _servicoService.Add(servico);
        return CreatedAtAction(nameof(GetServicoById), new { id = createdServico.EmpCodigo }, createdServico);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateServico(TbServico servico)
    {
        if (servico == null)
        {
            return BadRequest("Serviço inválido ou ID não corresponde.");
        }
        
        var updatedServico = await _servicoService.Update(servico);
        if (updatedServico == null)
        {
            return NotFound();
        }
        
        return Ok(updatedServico);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServico(int id)
    {
        try
        {
            await _servicoService.Delete(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
}
