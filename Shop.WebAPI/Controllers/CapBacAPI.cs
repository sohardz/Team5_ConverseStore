﻿using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.ViewModels.ViewModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CapBacAPI : ControllerBase
{
    private readonly ILogger<CapBacAPI> _logger;
    private readonly ICapBacServices _capBacServices;

    public CapBacAPI(ILogger<CapBacAPI> logger, ICapBacServices capBacServices)
    {
        _capBacServices = capBacServices;
        _logger = logger;
    }

    // GET: api/<CapBacAPI>
    [HttpGet]
    public async Task<List<CapBacVM>> GetAll()
    {
        return await _capBacServices.GetAll();
    }

    [HttpGet("capbac/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var capbac = await _capBacServices.GetById(id);
        if (capbac == null)
        {
            return BadRequest("Can't find capbac");
        }
        return Ok(capbac);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CapBacVM cb)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var check = await _capBacServices.Create(cb);
        if (check == Guid.Empty)
        {
            return BadRequest();
        }
        else
        {
            return await GetById(check);
        }
        //var mausac = await _capBacServices.GetById(capbacId);
        //return CreatedAtAction(nameof(GetById), new { id = capbacId }, mausac);
    }

    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] CapBacVM cb)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        cb.Id = id;
        var affectedResult = await _capBacServices.Edit(cb);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var affectedResult = await _capBacServices.Delete(id);
        if (affectedResult == 0)
            return BadRequest();
        return Ok();
    }
}
