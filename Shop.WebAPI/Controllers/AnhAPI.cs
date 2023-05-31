using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnhAPI : ControllerBase
{
    private readonly ILogger<AnhAPI> _logger;
    private readonly IAnhServices _anhServices;

    public AnhAPI(ILogger<AnhAPI> logger, IAnhServices anhServices)
    {
        _logger = logger;
        _anhServices = anhServices;
    }

    // GET: api/<AnhAPI>
    [HttpGet]
    public async Task<List<AnhVM>> GetAllAnhVM()
    {
        return await _anhServices.GetAll();
    }

    // PUT api/<ChucVuAPI>/5
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] AnhVM anhVM)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var check = await _anhServices.Create(anhVM);
        if (check == 0) return BadRequest();
        else
        {
            HttpContext.Response.StatusCode = 201;
            return Ok(anhVM);
        }
        //var anh = await _anhServices.GetById(anhId);
        //return CreatedAtAction(nameof(GetById), new { id = anhId }, anh);
    }

    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] AnhVM anhVM)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        anhVM.Id = id;
        var affectedResult = await _anhServices.Edit(anhVM);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }

    [HttpGet("anh/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var anh = await _anhServices.GetById(id);
        if (anh == null)
        {
            return BadRequest("Can't find anh");
        }
        return Ok(anh);
    }

    // DELETE api/<ChucVuAPI>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _anhServices.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}
