using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class ModuloController : ControllerBase
{
    private readonly IModuloService _moduloService;
    public ModuloController(IModuloService moduloService)
    {
        _moduloService = moduloService;
    }
    [HttpGet]
    public async Task<ActionResult> GetAllModulos()
    {
        var modulos = await _moduloService.GetAll();
        return Ok(modulos);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetModuloById(int id)
    {
        var modulo = await _moduloService.GetById(id);
        if (modulo == null)
        {
            return NotFound($"Nenhum Módulo Encontrado com o Id: {id}");
        }
        return Ok(modulo);
    }
    [HttpPost]
    public async Task<ActionResult> AddModulo(TbModulo modulo)
    {
        if (modulo == null)
        {
            return BadRequest("Módulo não pode ser nulo.");
        }
        try
        {
            await _moduloService.Add(modulo);
            return CreatedAtAction(nameof(GetModuloById), new { id = modulo.ModCodigo }, modulo);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
    [HttpPut]
    public async Task<ActionResult> UpdateModulo(TbModulo modulo)
    {
        if (modulo == null)
        {
            return BadRequest("Módulo não pode ser nulo.");
        }
        try
        {
            await _moduloService.Update(modulo);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteModulo(int id)
    {
        try
        {
            await _moduloService.Delete(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
