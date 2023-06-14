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

	[HttpGet("get-all/{id}")]
	public async Task<IActionResult> GetAll([FromRoute] Guid id)
	{
		var sanpham = await _cTHoaDonServices.GetAll(id);
		if (sanpham.Count == 0)
		{
			return BadRequest("Không thể tìm chi tiết hóa đơn");
		}
		return Ok(sanpham);
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] CTHoaDonVM request) // giỏ hàng >= 1 List<CTHoaDonVM> ->  body list json 
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		var cthdId = await _cTHoaDonServices.Create(request);
		if (cthdId == Guid.Empty)
		{
            return BadRequest();
        }
		else
		{
			return Ok(cthdId);
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
