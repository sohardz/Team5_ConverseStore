using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChucVuAPI : ControllerBase
{
    private readonly ILogger<ChucVuAPI> _logger;
    private readonly IChucVuService _chucVuService;

    public ChucVuAPI(ILogger<ChucVuAPI> logger, IChucVuService chucVuService)
    {
        _logger = logger;
        _chucVuService = chucVuService;
    }

    // GET: api/<ChucVuAPI>
    [HttpGet]
    public async Task<List<ChucVuVM>> GetAllChucVuVM()
    {
        return await _chucVuService.GetAll();
    }

    // PUT api/<ChucVuAPI>/5
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Them([FromForm] ChucVuVM cv)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var chucvuId = await _chucVuService.Create(cv);
        if (chucvuId == 0)
            return BadRequest();
        else
        {
            HttpContext.Response.StatusCode = 201;
            return Ok(cv);
        }
        //var chucvu = await _chucVuService.GetById(chucvuId);
        //return CreatedAtAction(nameof(GetById), new { id = chucvuId }, chucvu);
    }

    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]

    public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] ChucVuVM cv)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        cv.Id = id;
        var affectedResult = await _chucVuService.Edit(cv);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }

    [HttpGet("chucvu/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var chucvu = await _chucVuService.GetById(id);
        if (chucvu == null)
        {
            return BadRequest("Can't find chucvu");
        }
        return Ok(chucvu);
    }

    // DELETE api/<ChucVuAPI>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _chucVuService.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}