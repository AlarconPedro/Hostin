using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class PessoasController : ControllerBase
{
    private readonly IPessoasService _pessoaService;

    public PessoasController(IPessoasService pessoaService)
    {
        _pessoaService = pessoaService;
    }
    [HttpGet]
    public async Task<ActionResult> GetAllPessoas()
    {
        var pessoas = await _pessoaService.GetAll();
        return Ok(pessoas);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetPessoaById(int id)
    {
        var pessoa = await _pessoaService.GetById(id);
        if (pessoa == null)
        {
            return NotFound($"Nenhuma Pessoa Encontrada com o Id: {id}");
        }
        return Ok(pessoa);
    }
    [HttpPost]
    public async Task<ActionResult> AddPessoa(TbPessoa pessoa)
    {
        if (pessoa == null)
        {
            return BadRequest("Pessoa cannot be null.");
        }
        try
        {
            await _pessoaService.Add(pessoa);
            return CreatedAtAction(nameof(GetPessoaById), new { id = pessoa.PesCodigo }, pessoa);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
    [HttpPut]
    public async Task<ActionResult> UpdatePessoa(TbPessoa pessoa)
    {
        if (pessoa == null)
        {
            return BadRequest("Pessoa cannot be null.");
        }
        try
        {
            await _pessoaService.Update(pessoa);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePessoa(int id)
    {
        try
        {
            await _pessoaService.Delete(id);
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
