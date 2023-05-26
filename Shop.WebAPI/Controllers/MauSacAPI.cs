using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MauSacAPI : ControllerBase
{
    private readonly ILogger<MauSacAPI> _logger;
    private readonly IMauSacService _mauSacService;

    public MauSacAPI(ILogger<MauSacAPI> logger, IMauSacService mauSacService)
    {
        _logger = logger;
        _mauSacService = mauSacService;
    }

    // GET: api/<MauSaAPI>
    [HttpGet]
    public async Task<List<MauSacVM>> GetAllMauSacVM()
    {
        return await _mauSacService.GetAll();
    }

    // PUT api/<MauSaAPI>/5
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Them([FromForm] MauSacVM ms)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var mausacId = await _mauSacService.Create(ms);
        if (mausacId == 0)
            return BadRequest();
        var mausac = await _mauSacService.GetById(mausacId);
        return CreatedAtAction(nameof(GetById), new { id = mausacId }, mausac);
    }

    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromForm] MauSacVM ms)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        ms.Id = id;
        var affectedResult = await _mauSacService.Edit(ms);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }

    [HttpGet("mausac/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var mausac = await _mauSacService.GetById(id);
        if (mausac == null)
        {
            return BadRequest("Can't find chucvu");
        }
        return Ok(mausac);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var affectedResult = await _mauSacService.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }

    //private bool MauSacExists(int id)
    //{
    //    return (_context.MauSacs?.Any(e => e.Id == id)).GetValueOrDefault();
    //}
}
