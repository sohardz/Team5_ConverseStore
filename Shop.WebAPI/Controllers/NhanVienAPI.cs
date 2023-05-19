using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.Services;
using Shop.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienAPI : ControllerBase
    {
        private readonly ILogger<NhanVienAPI> _logger;
        private readonly INhanVienServices _nhanVienServices;

        public NhanVienAPI(ILogger<NhanVienAPI> logger, INhanVienServices nhanVienServices)
        {
            _logger = logger;
            _nhanVienServices = nhanVienServices;
        }

        // GET: api/<NhanVienAPI>
        [HttpGet]
        public async Task<List<NhanVienVM>> GetAllChucVuVM()
        {
            return await _nhanVienServices.GetAllNhanVien();
        }

        // GET api/<NhanVienAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NhanVienAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NhanVienAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NhanVienAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
