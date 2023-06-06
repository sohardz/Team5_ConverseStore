using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.ViewModels.ViewModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NhanVienAPI : ControllerBase
{
    private readonly ILogger<NhanVienAPI> _logger;
    private readonly INhanVienServices _nhanVienServices;

    public NhanVienAPI(ILogger<NhanVienAPI> logger, INhanVienServices nhanVienServices)
    {
        _logger = logger;
        _nhanVienServices = nhanVienServices;
    }

    // GET: api/<NhanVienAPI>
    [HttpGet]
    public async Task<List<NhanVienVM>> GetAllNhanVienVM()
    {
        return await _nhanVienServices.GetAll();
    }

    [HttpPost]
    
    public async Task<IActionResult> Create([FromBody] NhanVienVM nv)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var khachHangId = await _nhanVienServices.Create(nv);
        if (khachHangId == Guid.Empty)
            return BadRequest();
        else
        {
            HttpContext.Response.StatusCode = 201;
            return Ok(nv);
        }
        //var khachhang = await _khachhangServices.GetById(khachHangId);
        //return CreatedAtAction(nameof(GetById), new { id = khachHangId }, khachhang);
    }

    [HttpPut("{id}")]
    
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] NhanVienVM kh)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        kh.Id = id;
        var affectedResult = await _nhanVienServices.Edit(kh);
        if (affectedResult == Guid.Empty)
            return BadRequest();
        return Ok();
    }

    [HttpGet("nhanvien/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var khachhang = await _nhanVienServices.GetById(id);
        if (khachhang == null)
        {
            return BadRequest("Can't find nhanvien");
        }
        return Ok(khachhang);
    }

    // DELETE api/<KhachHangsAPI>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _nhanVienServices.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}
