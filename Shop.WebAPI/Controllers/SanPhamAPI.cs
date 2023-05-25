using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamAPI : ControllerBase
    {
        private readonly ILogger<SanPhamAPI> _logger;
        private readonly ISanPhamServices _sanPhamService;

        public SanPhamAPI(ILogger<SanPhamAPI> logger, ISanPhamServices sanPhamServices)
        {
            _logger = logger;
            _sanPhamService = sanPhamServices;
        }
        // GET: api/<SanPhamAPI>
        [HttpGet]
        public async Task<List<SanPhamVM>> GetAllSanPhamVM() 
        {
            return await _sanPhamService.GetAllSanPham();
        }

        // GET api/<SanPhamAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SanPhamAPI>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<SanPhamAPI>/5
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Them([FromForm] SanPhamVM sp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sanphamId = await _sanPhamService.Them(sp);
            if (sanphamId == 0)
                return BadRequest();
            var sanpham = await _sanPhamService.GetById(sanphamId);
            return CreatedAtAction(nameof(GetById), new { id = sanphamId }, sanpham);
        }
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] SanPhamVM sp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            sp.Id = id;
            var affectedResult = await _sanPhamService.Sua(sp);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("sanpham/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sanpham = await _sanPhamService.GetById(id);
            if (sanpham == null)
            {
                return BadRequest("Can't find sanpham");
            }
            return Ok(sanpham);
        }
        // DELETE api/<ChucVuAPI>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _sanPhamService.Xoa(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}