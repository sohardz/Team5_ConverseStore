using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.ViewModels.ViewModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GioHangAPI : ControllerBase
{
    private readonly ILogger<GioHangAPI> _logger;
    private readonly IGioHangService _gioHangService;

    public GioHangAPI(ILogger<GioHangAPI> logger, IGioHangService gioHangservice)
    {
        _logger = logger;
        _gioHangService = gioHangservice;
    }

    // GET: api/<GioHangAPI>
    [HttpGet]
    public async Task<List<GioHangVM>> GetAllGioHangVM()
    {
        return await _gioHangService.GetAll();
    }

    // PUT api/<GioHangAPI>/5
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Them([FromForm] GioHangVM gh)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var giohangId = await _gioHangService.Create(gh);
        if (giohangId == 0)
            return BadRequest();
        else
        {
            HttpContext.Response.StatusCode = 201;
            return Ok(gh);
        }
        //var giohang = await _gioHangService.GetById(giohangId);
        //return CreatedAtAction(nameof(GetById), new { id = giohangId }, giohang);
    }

    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] GioHangVM gh)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        gh.IdKh = id;
        var affectedResult = await _gioHangService.Edit(gh);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
    [HttpGet("giohang/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var giohang = await _gioHangService.GetById(id);
        if (giohang == null)
        {
            return BadRequest("Can't find giohang");
        }
        return Ok(giohang);
    }
    // DELETE api/<GioHangAPI>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _gioHangService.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}
