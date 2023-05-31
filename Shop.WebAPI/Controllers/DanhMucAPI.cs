using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DanhMucAPI : ControllerBase
{
    private readonly ILogger<DanhMucAPI> _logger;
    private readonly IDanhMucService _danhMucService;
    public DanhMucAPI(ILogger<DanhMucAPI> logger, IDanhMucService danhMucService)
    {
        _logger = logger;
        _danhMucService = danhMucService;
    }

    //// GET: api/<DanhMucAPI>
    [HttpGet]
    public async Task<List<DanhMucVM>> GetAllDanhMucVM()
    {
        return await _danhMucService.GetAll();
    }

    //// POST api/<DanhMucAPI>
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Create([FromForm] DanhMucVM dm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var danhMucId = await _danhMucService.Create(dm);
        if (danhMucId == 0)
            return BadRequest();
        else
        {
            HttpContext.Response.StatusCode = 201;
            return Ok(dm);
        }
        //var danhMuc = await _danhMucService.GetById(danhMucId);
        //return CreatedAtAction(nameof(GetById), new { id = danhMucId }, danhMuc);
    }

    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Edit([FromRoute] Guid id, [FromForm] DanhMucVM dm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        dm.Id = id;
        var affectedResult = await _danhMucService.Edit(dm);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }

    [HttpGet("danhmuc/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var danhMuc = await _danhMucService.GetById(id);
        if (danhMuc == null)
        {
            return BadRequest("Khong tim thay danh muc");
        }
        return Ok(danhMuc);
    }


    //// DELETE api/<DanhMucAPI>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _danhMucService.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}
