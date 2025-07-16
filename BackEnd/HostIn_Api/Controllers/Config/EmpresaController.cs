using Hostin.Core.Entities.Tabelas;
using Hostin.Core.Interfaces.Config;
using Hostin.Infra.Data.Services.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers.Config;

[Route("api/[controller]")]
[ApiController]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaService _service;

    public EmpresaController(IEmpresaService empresaService)
    {
        _service = empresaService;
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
            return NotFound($"Nenhuma Empresa Encontrada com o Id: {id}");
        }
        return Ok(retorno);
    }

    [HttpPost]
    public async Task<ActionResult> Add(TbComprasItens empresa)
    {
        if (empresa == null)
        {
            return BadRequest("Cidade cannot be null.");
        }
        try
        {
            await _service.Add(empresa);
            return CreatedAtAction(nameof(GetById), new { id = empresa.EmpCodigo }, empresa);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(TbComprasItens empresa)
    {
        if (empresa == null)
        {
            return BadRequest("Cidade cannot be null.");
        }
        try
        {
            return Ok(await _service.Update(empresa));
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
