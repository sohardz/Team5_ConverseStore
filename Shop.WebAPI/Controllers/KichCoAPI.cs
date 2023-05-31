using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KichCoAPI : ControllerBase
{
    private readonly ILogger<KichCoAPI> _logger;
    private readonly IKichCoService _kichCoService;

    public KichCoAPI(ILogger<KichCoAPI> logger, IKichCoService kichCoService)
    {
        _logger = logger;
        _kichCoService = kichCoService;
    }

    // GET: api/KichCoAPI
    [HttpGet]
    public async Task<List<KichCoVM>> GetAllKichCoVM()
    {

        return await _kichCoService.GetAll();
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult> Them([FromForm] KichCoVM kc)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("ModelState");
        }
        var kichcoId = await _kichCoService.Create(kc);
        if (kichcoId == 0)
            return BadRequest();
        else
        {
            HttpContext.Response.StatusCode = 201;
            return Ok(kc);
        }
        //var kichco = await _kichCoService.GetById(kichcoId);
        //return CreatedAtAction(nameof(GetById), new { id = kichcoId }, kichco);
    }

    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] KichCoVM kc)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        kc.Id = id;
        var affectedResult = await _kichCoService.Edit(kc);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }

    [HttpGet("kichco/{id}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var kichco = await _kichCoService.GetById(id);
        if (kichco == null)
        {
            return BadRequest("Can't find kichco");
        }
        return Ok(kichco);
    }

    // DELETE: api/KichCoAPI/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _kichCoService.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}
