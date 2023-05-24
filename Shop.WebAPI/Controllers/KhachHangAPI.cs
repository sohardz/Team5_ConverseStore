using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

namespace Shop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangAPI : ControllerBase
    {
        private readonly ILogger<KhachHangAPI> _logger;
        private readonly IKhachhangServices _khachhangServices;

        public KhachHangAPI(ILogger<KhachHangAPI> logger, IKhachhangServices khachhangServices)
        {
            _logger = logger;
            _khachhangServices = khachhangServices;
        }

        // GET: api/<KhachHangsAPI>
        [HttpGet]
        public async Task<List<KhachHangVM>> GetAllKhachhangM()
        {
            return await _khachhangServices.GetAllKhachhang();
        }

        // PUT api/<KhachHangsAPI>/5
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Them([FromForm] KhachHangVM kh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var khachHangId = await _khachhangServices.Them(kh);
            if (khachHangId == 0)
                return BadRequest();
            var khachhang = await _khachhangServices.GetById(khachHangId);
            return CreatedAtAction(nameof(GetById), new { id = khachHangId }, khachhang);
        }
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] KhachHangVM kh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            kh.Id = id;
            var affectedResult = await _khachhangServices.Sua(kh);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("khachhang/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var khachhang = await _khachhangServices.GetById(id);
            if (khachhang == null)
            {
                return BadRequest("Can't find khachhang");
            }
            return Ok(khachhang);
        }
        // DELETE api/<KhachHangsAPI>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _khachhangServices.Xoa(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPost("Capbac")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ThemCapBac([FromForm] CapBacVM cb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var capbacId = await _khachhangServices.ThemCapBac(cb);
            if (capbacId == 0)
                return BadRequest();
            var capbac = await _khachhangServices.GetByIdCapBac(capbacId);
            return CreatedAtAction(nameof(GetByIdCapbac), new { id = capbacId }, capbac);
        }
        [HttpGet("khachhang/capbac/{id}")]
        public async Task<IActionResult> GetByIdCapbac(int id)
        {
            var capbac = await _khachhangServices.GetByIdCapBac(id);
            if (capbac == null)
            {
                return BadRequest("Can't find Cap Bac");
            }
            return Ok(capbac);
        }
    }
}
