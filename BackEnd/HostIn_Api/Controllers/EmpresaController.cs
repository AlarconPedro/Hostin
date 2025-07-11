using Hostin.Core.Interfaces;
using HostIn.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostIn_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaService _empresaService;

    public EmpresaController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllEmpresas()
    {
        var empresas = await _empresaService.GetAll();
        return Ok(empresas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetEmpresaById(int id)
    {
        var empresa = await _empresaService.GetById(id);
        if (empresa == null)
        {
            return NotFound($"Nenhuma Empresa Encontrada com o Id: {id}");
        }
        return Ok(empresa);
    }

    [HttpPost]
    public async Task<ActionResult> AddEmpresa(TbEmpresa empresa)
    {
        if (empresa == null)
        {
            return BadRequest("Empresa cannot be null.");
        }
        try
        {
            await _empresaService.AddEmpresa(empresa);
            return CreatedAtAction(nameof(GetEmpresaById), new { id = empresa.EmpCodigo }, empresa);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateEmpresa(TbEmpresa empresa)
    {
        if (empresa == null)
        {
            return BadRequest("Empresa cannot be null.");
        }
        try
        {
            return Ok(await _empresaService.Update(empresa));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
