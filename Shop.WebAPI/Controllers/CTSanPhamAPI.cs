using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

namespace Shop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTSanPhamAPI : ControllerBase
    {
        private readonly ILogger<CTSanPhamAPI> _logger;
        private readonly ICTSanPhamService _sanPhamService;

        public CTSanPhamAPI(ILogger<CTSanPhamAPI> logger, ICTSanPhamService sanPhamService)
        {
            _logger = logger;
            _sanPhamService = sanPhamService;
        }
        [HttpGet]
        public async Task<List<CTSanPhamVM>> GetAll()
        {
            return await _sanPhamService.GetAll();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CTSanPhamVM request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sanphamId = await _sanPhamService.Create(request);
            if (sanphamId == 0)
                return BadRequest();
            var sanpham = await _sanPhamService.GetById(sanphamId);
            return CreatedAtAction(nameof(GetById), new { id = sanphamId }, sanpham);
        }

        [HttpGet("sanpham/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sanpham = await _sanPhamService.GetById(id);
            if (sanpham == null)
            {
                return BadRequest("Không thể tìm sản phẩm");
            }
            return Ok(sanpham);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] CTSanPhamVM p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            p.Id = id;
            var affectedResult = await _sanPhamService.Edit(p);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _sanPhamService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

    }
}
