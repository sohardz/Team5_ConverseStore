using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.ViewModels.ViewModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SanPhamAPI : ControllerBase
{
    private readonly ILogger<SanPhamAPI> _logger;
    private readonly ISanPhamService _sanPhamService;

    public SanPhamAPI(ILogger<SanPhamAPI> logger, ISanPhamService sanPhamServices)
    {
        _logger = logger;
        _sanPhamService = sanPhamServices;
    }
    // GET: api/<SanPhamAPI>
    [HttpGet]
    public async Task<List<SanPhamVM>> GetAllSanPhamVM()
    {
        return await _sanPhamService.GetAll();
    }

    // PUT api/<SanPhamAPI>/5
    [HttpPost]
    public async Task<IActionResult> Them([FromBody] SanPhamVM sp)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var sanphamId = await _sanPhamService.Create(sp);
        if (sanphamId == Guid.Empty)
            return BadRequest();
        else
        {
            HttpContext.Response.StatusCode = 201;
            return Ok(sp);
        }
        //var sanpham = await _sanPhamService.GetById(sanphamId);
        //return CreatedAtAction(nameof(GetById), new { id = sanphamId }, sanpham);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SanPhamVM sp)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        sp.Id = id;
        var affectedResult = await _sanPhamService.Edit(sp);
        if (affectedResult == Guid.Empty)
            return BadRequest();
        return Ok(sp);
    }

    [HttpGet("sanpham/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var sanpham = await _sanPhamService.GetById(id);
        if (sanpham == null)
        {
            return BadRequest("Can't find sanpham");
        }
        return Ok(sanpham);
    }

    // DELETE api/<ChucVuAPI>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _sanPhamService.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}