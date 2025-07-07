using ActizLims.API.Data;
using ActizLims.API.Models;
using ActizLims.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ActizLims.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private readonly IAmostraService _amostraService;
    public HomeController(IAmostraService amostraService)
    {
        _amostraService = amostraService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int idUser)
    {
        var amostras = await _amostraService.GetAllAsync(idUser);
        return Ok(amostras);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id, int idUser)
    {
        var amostra = await _amostraService.GetByIdAsync(id, idUser);
        return amostra is null ? NotFound() : Ok(amostra);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Amostra amostra)
    {
        var created = await _amostraService.CreateAsync(amostra);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Amostra amostra)
    {
        if (id != amostra.Id) return BadRequest();
        var updated = await _amostraService.UpdateAsync(amostra);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _amostraService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }

    [HttpGet("relatorio")]
    public async Task<IActionResult> GetRelatorio(int idUser)
    {
        var amostras = await _amostraService.GetFinalizadasUltimos30DiasAsync(idUser);
        return Ok(amostras);
    }
}

