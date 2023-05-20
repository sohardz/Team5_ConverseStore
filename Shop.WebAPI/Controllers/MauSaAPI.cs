using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices;
using Shop.Application.ViewModels;
using Shop.Data.Context;
using Shop.Data.Models;

namespace Shop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MauSaAPI : ControllerBase
    {
        private readonly ILogger<MauSaAPI> _logger;
        private readonly IMauSacService _mauSacService;

        public MauSaAPI(ILogger<MauSaAPI> logger, IMauSacService mauSacService)
        {
            _logger = logger;
            _mauSacService = mauSacService;
        }

        // GET: api/<MauSaAPI>
        [HttpGet]
        public async Task<List<MauSacVM>> GetAllMauSacVM()
        {
            return await _mauSacService.GetAllMauSac();
        }

        // GET api/<MauSaAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MauSaAPI>
        //[HttpPost]
        //public void Post([FromBody] MauSacVM ms)
        //{

        //}

        // PUT api/<MauSaAPI>/5
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Them([FromForm] MauSacVM ms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mausacId = await _mauSacService.Them(ms);
            if (mausacId == 0)
                return BadRequest();
            var mausac = await _mauSacService.GetById(mausacId);
            return CreatedAtAction(nameof(GetById), new { id = mausacId }, mausac);
        }
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] MauSacVM ms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ms.Id = id;
            var affectedResult = await _mauSacService.Sua(ms);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("chucvu/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mausac = await _mauSacService.GetById(id);
            if (mausac == null)
            {
                return BadRequest("Can't find chucvu");
            }
            return Ok(mausac);
        }
        // DELETE api/<MauSaAPI>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _mauSacService.Xoa(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        //private bool MauSacExists(int id)
        //{
        //    return (_context.MauSacs?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
