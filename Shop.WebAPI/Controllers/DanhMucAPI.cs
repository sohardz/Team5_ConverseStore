﻿using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.ViewModels.ViewModels;


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
        _danhMucService = danhMucService;
        _logger = logger;
 
    }

    //// GET: api/<DanhMucAPI>
    [HttpGet("get-all-danhMuc")]
    public async Task<List<DanhMucVM>> GetAll()
    {
        return await _danhMucService.GetAll();
    }

    [HttpGet("get-danhMuc/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var danhMuc = await _danhMucService.GetById(id);
        if (danhMuc == null)
        {
            return BadRequest("Can't find danhmuc");
        }
        return Ok(danhMuc);
    }

    [HttpPost("create-danhMuc")]
    public async Task<IActionResult> Create([FromBody] DanhMucVM dm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var danhMucId = await _danhMucService.Create(dm);
        if (danhMucId == Guid.Empty)
            return BadRequest();
        else
        {
            return await GetById(danhMucId);
        }       
    }

    [HttpPut("edit-danhMuc")]
    public async Task<IActionResult> Edit([FromBody] DanhMucVM dm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var affectedResult = await _danhMucService.Edit(dm);
        if (affectedResult == Guid.Empty)
            return BadRequest();
        return Ok();
    }

    
    [HttpDelete("delete-danhMuc/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _danhMucService.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}
