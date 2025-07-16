using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Estoque;

[Route("api/[controller]")]
[ApiController]
public class ComprasItensController : ControllerBase
{
    private readonly IComprasItensService _comprasItensService;

    public ComprasItensController(IComprasItensService comprasItensService)
    {
        _comprasItensService = comprasItensService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllComprasItens()
    {
        var comprasItens = await _comprasItensService.GetAll();
        return Ok(comprasItens);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetComprasItemById(int id)
    {
        var comprasItem = await _comprasItensService.GetById(id);
        if (comprasItem == null)
        {
            return NotFound($"Nenhum Item de Compra Encontrado com o Id: {id}");
        }
        return Ok(comprasItem);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComprasItem(TbComprasIten comprasItem)
    {
        if (comprasItem == null)
        {
            return BadRequest("Item de Compra não pode ser nulo.");
        }
        var createdComprasItem = await _comprasItensService.Add(comprasItem);
        return CreatedAtAction(nameof(GetComprasItemById), new { id = createdComprasItem.ComCodigo }, createdComprasItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateComprasItem(TbComprasIten comprasItem)
    {
        if (comprasItem == null)
        {
            return BadRequest("Item de Compra inválido ou ID não corresponde.");
        }
        
        var updatedComprasItem = await _comprasItensService.Update(comprasItem);
        if (updatedComprasItem == null)
        {
            return NotFound($"Nenhum Item de Compra Encontrado com o Id: {comprasItem.ComCodigo}");
        }
        
        return Ok(updatedComprasItem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComprasItem(int id)
    {
        var deleted = await _comprasItensService.Delete(id);
        if (!deleted)
        {
            return NotFound($"Nenhum Item de Compra Encontrado com o Id: {id}");
        }
        return NoContent();
    }
}
