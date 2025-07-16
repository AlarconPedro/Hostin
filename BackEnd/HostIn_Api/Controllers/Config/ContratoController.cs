using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class ContratoController : ControllerBase
{
    private readonly IContratoService _contratoService;

    public ContratoController(IContratoService contratoService)
    {
        _contratoService = contratoService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllContratos()
    {
        var contratos = await _contratoService.GetAll();
        return Ok(contratos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetContratoById(int id)
    {
        var contrato = await _contratoService.GetById(id);
        if (contrato == null)
        {
            return NotFound($"Nenhum Contrato Encontrado com o Id: {id}");
        }
        return Ok(contrato);
    }

    [HttpPost]
    public async Task<ActionResult> AddContrato(TbContrato contrato)
    {
        if (contrato == null)
        {
            return BadRequest("Contrato cannot be null.");
        }
        try
        {
            await _contratoService.Add(contrato);
            return CreatedAtAction(nameof(GetContratoById), new { id = contrato.CntCodigo }, contrato);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateContrato(TbContrato contrato)
    {
        if (contrato == null)
        {
            return BadRequest("Contrato cannot be null.");
        }
        try
        {
            await _contratoService.Update(contrato);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteContrato(int id)
    {
        try
        {
            await _contratoService.Delete(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
}
