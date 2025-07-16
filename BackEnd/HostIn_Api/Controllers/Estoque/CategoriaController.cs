using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Estoque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Estoque;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;
    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCategorias()
    {
        var categorias = await _categoriaService.GetAll();
        return Ok(categorias);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoriaById(int id)
    {
        var categoria = await _categoriaService.GetById(id);
        if (categoria == null)
        {
            return NotFound($"Nenhuma Categoria Encontrada com o Id: {id}");
        }
        return Ok(categoria);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategoria([FromBody] TbCategoria categoria)
    {
        if (categoria == null)
        {
            return BadRequest("Categoria não pode ser nula.");
        }
        var createdCategoria = await _categoriaService.Add(categoria);
        return CreatedAtAction(nameof(GetCategoriaById), new { id = createdCategoria.CatCodigo }, createdCategoria);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategoria(TbCategoria categoria)
    {
        if (categoria == null)
        {
            return BadRequest("Categoria inválida ou ID não corresponde.");
        }
        
        var updatedCategoria = await _categoriaService.Update(categoria);
        if (updatedCategoria == null)
        {
            return NotFound($"Nenhuma Categoria Encontrada com o Id: {categoria.CatCodigo}");
        }
        
        return Ok(updatedCategoria);
    }
}
