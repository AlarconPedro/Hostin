using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class PessoasController : ControllerBase
{
    private readonly IPessoasService _service;

    public PessoasController(IPessoasService pessoaService)
    {
        _service = pessoaService;
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
            return NotFound($"Nenhuma Pessoa Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbPessoa pessoa)
    {
        if (pessoa == null)
        {
            return BadRequest("Pessoa cannot be null.");
        }
        try
        {
            await _service.Add(pessoa);
            return CreatedAtAction(nameof(GetById), new { id = pessoa.PesCodigo }, pessoa);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbPessoa pessoa)
    {
        if (pessoa == null)
        {
            return BadRequest("Cidade cannot be null.");
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
            return NotFound($"Nenhuma Empresa Encontrada com o Id: {id}");
        }
        return NoContent(); // 204 No Content for successful deletion
    }
}
