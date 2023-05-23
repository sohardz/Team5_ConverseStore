using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.Services;
using Shop.Application.ViewModels;
using Shop.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers
{
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
            return await _danhMucService.GetAllDanhMuc();
        }


        //// POST api/<DanhMucAPI>
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Them([FromForm] DanhMucVM dm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var danhMucId = await _danhMucService.Them(dm);
            if (danhMucId == 0)
                return BadRequest();
            var danhMuc = await _danhMucService.GetById(danhMucId);
            return CreatedAtAction(nameof(GetById), new { id = danhMucId }, danhMuc);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> Sua([FromRoute] int id, [FromForm] DanhMucVM dm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dm.Id = id;
            var affectedResult = await _danhMucService.Sua(dm);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpGet("danhmuc/{id}")]
        public async Task<IActionResult> GetById(int id)
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
        public async Task<IActionResult> Xoa(int id)
        {
            var affectedResult = await _danhMucService.Xoa(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
