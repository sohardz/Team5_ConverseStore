using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.ViewModels.ViewModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CTGioHangAPI : ControllerBase
{

	private readonly ILogger<CTGioHangAPI> _logger;
	private readonly ICTGioHangServices _ctgioHangService;

	public CTGioHangAPI(ILogger<CTGioHangAPI> logger, ICTGioHangServices ctgioHangservice)
	{
		_logger = logger;
		_ctgioHangService = ctgioHangservice;
	}

	// GET: api/<CTGioHangAPI>
	[HttpGet]
	public async Task<List<CTGioHangVM>> GetAllGioHangVM()
	{
		return await _ctgioHangService.GetAll();
	}

	// PUT api/<CTGioHangAPI>/5
	[HttpPost]
	[Consumes("multipart/form-data")]
	public async Task<IActionResult> Them([FromForm] CTGioHangVM ctgh)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		var ctgiohangId = await _ctgioHangService.Create(ctgh);
		if (ctgiohangId == Guid.Empty)
			return BadRequest();
		else
		{
			HttpContext.Response.StatusCode = 201;
			return Ok(ctgh);
		}
		//var ctgiohang = await _ctgioHangService.GetById(ctgiohangId);
		//return CreatedAtAction(nameof(GetById), new { id = ctgiohangId }, ctgiohang);
	}

	[HttpPut("{id}")]
	[Consumes("multipart/form-data")]
	public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] CTGioHangVM ctgh)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		ctgh.Id = id;
		var affectedResult = await _ctgioHangService.Edit(ctgh);
		if (affectedResult == Guid.Empty)
			return BadRequest();
		return Ok();
	}
	[HttpGet("ctgiohang/{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var ctgiohang = await _ctgioHangService.GetById(id);
		if (ctgiohang == null)
		{
			return BadRequest("Can't find ctgiohang");
		}
		return Ok(ctgiohang);
	}
	// DELETE api/<CTGioHangAPI>/5
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var affectedResult = await _ctgioHangService.Delete(id);
		if (affectedResult == 0)
			return BadRequest();
		return Ok();
	}
}
