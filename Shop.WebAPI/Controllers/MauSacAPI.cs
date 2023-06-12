using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.ViewModels.ViewModels;


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
	public async Task<List<MauSacVM>> GetAll()
	{
		return await _mauSacService.GetAll();
	}

	// PUT api/<MauSaAPI>/5
	[HttpPost]
	public async Task<IActionResult> Them([FromBody] MauSacVM ms)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		var mausacId = await _mauSacService.Create(ms);
		if (mausacId == Guid.Empty)
			return BadRequest();
		else
		{
			HttpContext.Response.StatusCode = 201;
			return Ok(ms);
		}
		//var mausac = await _mauSacService.GetById(mausacId);
		//return CreatedAtAction(nameof(GetById), new { id = mausacId }, mausac);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] MauSacVM ms)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		ms.Id = id;
		var affectedResult = await _mauSacService.Edit(ms);
		if (affectedResult == Guid.Empty)
			return BadRequest();
		return Ok(ms);
	}

	[HttpGet("mausac/{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var mausac = await _mauSacService.GetById(id);
		if (mausac == null)
		{
			return BadRequest("Can't find chucvu");
		}
		return Ok(mausac);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var affectedResult = await _mauSacService.Delete(id);
		if (affectedResult == 0)
			return BadRequest();
		return Ok();
	}
}
