using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;

using Shop.ViewModels.ViewModels;

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class KhachHangAPI : ControllerBase
{
    private readonly ILogger<KhachHangAPI> _logger;
    private readonly IKhachhangServices _khachhangServices;

    public KhachHangAPI(ILogger<KhachHangAPI> logger, IKhachhangServices khachhangServices)
    {
        _logger = logger;
        _khachhangServices = khachhangServices;
    }

    // GET: api/<KhachHangsAPI>
    [HttpGet]
    public async Task<List<KhachHangVM>> GetAllKhachhangM()
    {
        return await _khachhangServices.GetAll();
    }

    // PUT api/<KhachHangsAPI>/5
    [HttpPost]
    public async Task<IActionResult> Them([FromBody] KhachHangVM kh)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var khachHangId = await _khachhangServices.Create(kh);
        if (khachHangId == Guid.Empty)
            return BadRequest();
        else
        {
            HttpContext.Response.StatusCode = 201;
            return Ok(kh);
        }
        //var khachhang = await _khachhangServices.GetById(khachHangId);
        //return CreatedAtAction(nameof(GetById), new { id = khachHangId }, khachhang);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] KhachHangVM kh)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        kh.Id = id;
        var affectedResult = await _khachhangServices.Edit(kh);
        if (affectedResult == Guid.Empty)
            return BadRequest();
        return Ok();
    }

    [HttpGet("khachhang/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var khachhang = await _khachhangServices.GetById(id);
        if (khachhang == null)
        {
            return BadRequest("Can't find khachhang");
        }
        return Ok(khachhang);
    }

    // DELETE api/<KhachHangsAPI>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _khachhangServices.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}
