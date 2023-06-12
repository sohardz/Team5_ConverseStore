using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.ViewModels.ViewModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GiamGiaAPI : ControllerBase
{
	private readonly ILogger<GiamGiaAPI> _logger;
	private readonly IGiamGiaService _giamgiaService;

	public GiamGiaAPI(ILogger<GiamGiaAPI> logger, IGiamGiaService giamGiaService)
	{
		_logger = logger;
		_giamgiaService = giamGiaService;
	}

	// GET: api/<GiamGiaAPI>
	[HttpGet("get-all-giamgia")]
	public async Task<List<GiamGiaVM>> GetAllGiamGiaVM()
	{
		return await _giamgiaService.GetAll();
	}

	[HttpGet("get-giamgia/{id}")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var giamgia = await _giamgiaService.GetById(id);
		if (giamgia == null)
		{
			return BadRequest("Can't find giamgia");
		}
		return Ok(giamgia);
	}


	[HttpPost("create-giamgia")]
	public async Task<IActionResult> Create([FromBody] GiamGiaVM gg)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		var check = await _giamgiaService.Create(gg);
		if (check == Guid.Empty)
			return BadRequest();
		else
		{
			return await GetById(check);
		}
		//var giamgia = await _giamgiaService.GetById(giamgiaId);
		//return CreatedAtAction(nameof(GetById), new { id = giamgiaId }, giamgia);
	}

	[HttpPut("update-giamgia")]

	public async Task<IActionResult> Edit([FromBody] GiamGiaVM gg)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		var affectedResult = await _giamgiaService.Edit(gg);
		if (affectedResult == Guid.Empty)
			return BadRequest();
		return Ok();
	}



	[HttpDelete("delete-giamgia/{id}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var affectedResult = await _giamgiaService.Delete(id);
		if (affectedResult == 0)
			return BadRequest();
		return Ok();
	}
}
