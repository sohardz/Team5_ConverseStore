using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.Services;
using Shop.Application.ViewModels;

namespace Shop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamAPI : ControllerBase
    {
        private readonly ILogger<SanPhamAPI> _logger;
        private readonly ISanPhamService _sanPhamService;

        public SanPhamAPI(ILogger<SanPhamAPI> logger, ISanPhamService sanPhamService)
        {
            _logger = logger;
            _sanPhamService = sanPhamService;
        }
        [HttpGet]
        public async Task<List<SanPhamVM>> GetAll()
        {
            return await _sanPhamService.GetAll();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] SanPhamVM request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var sanphamId = await _sanPhamService.Them(request);
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
    }
}
