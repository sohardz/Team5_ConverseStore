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
    [HttpGet]
    public async Task<List<GiamGiaVM>> GetAllGiamGiaVM()
    {
        return await _giamgiaService.GetAll();
    }

    // PUT api/<GiamGiaAPI>/5
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] GiamGiaVM gg)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var giamgiaId = await _giamgiaService.Create(gg);
        if (giamgiaId == 0)
            return BadRequest();
        else
        {
            HttpContext.Response.StatusCode = 201;
            return Ok(gg);
        }
        //var giamgia = await _giamgiaService.GetById(giamgiaId);
        //return CreatedAtAction(nameof(GetById), new { id = giamgiaId }, giamgia);
    }
    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Edit([FromRoute] Guid id, [FromForm] GiamGiaVM gg)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        gg.Id = id;
        var affectedResult = await _giamgiaService.Edit(gg);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
    [HttpGet("giamgia/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var giamgia = await _giamgiaService.GetById(id);
        if (giamgia == null)
        {
            return BadRequest("Can't find giamgia");
        }
        return Ok(giamgia);
    }

    // DELETE api/<GiamGiaAPI>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _giamgiaService.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}
