using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.ViewModels.ViewModels;

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CTHoaDonAPI : ControllerBase
{
    private readonly ILogger<CTHoaDonAPI> _logger;
    private readonly ICTHoaDonServices _cTHoaDonServices;

    public CTHoaDonAPI(ILogger<CTHoaDonAPI> logger, ICTHoaDonServices cTHoaDonServices)
    {
        _cTHoaDonServices = cTHoaDonServices;
        _logger = logger;
    }

    [HttpGet("sanpham")]
    public async Task<IActionResult> GetById(Guid cthdid)
    {
        var sanpham = await _cTHoaDonServices.GetById(cthdid);
        if (sanpham == null)
        {
            return BadRequest("Không thể tìm sản phẩm");
        }
        return Ok(sanpham);
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] CTHoaDonVM request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var cthdId = await _cTHoaDonServices.Create(request);
        if (cthdId == Guid.Empty)
            return BadRequest();
        else
        {
            HttpContext.Response.StatusCode = 201;
            return Ok(request);
        }
        //var sanpham = await _cTHoaDonServices.GetById(cthdId);
        //return CreatedAtAction(nameof(GetById), new { id = cthdId, idsp = request.IdSanPham }, sanpham);
    }

    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] CTHoaDonVM p)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        p.Id = id;
        var affectedResult = await _cTHoaDonServices.Edit(p);
        if (affectedResult == Guid.Empty)
            return BadRequest();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid idhd, Guid ctspid)
    {
        var affectedResult = await _cTHoaDonServices.Delete(idhd, ctspid);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}
