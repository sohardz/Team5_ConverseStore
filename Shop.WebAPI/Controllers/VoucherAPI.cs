using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.Services;
using Shop.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherAPI : ControllerBase
    {

        private readonly ILogger<VoucherAPI> _logger;
        private readonly IVoucherService _voucherService;
        public VoucherAPI(ILogger<VoucherAPI> logger, IVoucherService voucherService)
        {
            _logger = logger;
            _voucherService = voucherService;
        }
        // GET: api/<VoucherAPI>
        [HttpGet]
        public async Task<List<VoucherVM>> GetAllVoucherVM()
        {
            return await _voucherService.GetAllVoucher();
        }

        // GET api/<VoucherAPI>/5
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Them([FromForm] VoucherVM v)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var voucherId = await _voucherService.Them(v);
            if (voucherId == 0)
                return BadRequest();
            var voucher = await _voucherService.GetById(voucherId);
            return CreatedAtAction(nameof(GetById), new { id = voucherId }, voucher);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> Sua([FromRoute] int id, [FromForm] VoucherVM v)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            v.Id = id;
            var affectedResult = await _voucherService.Sua(v);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("voucher/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var voucher = await _voucherService.GetById(id);
            if (voucher == null)
            {
                return BadRequest("Hong tim thay voucher");
            }
            return Ok(voucher);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Xoa(int id)
        {
            var affectedResult = await _voucherService.Xoa(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
