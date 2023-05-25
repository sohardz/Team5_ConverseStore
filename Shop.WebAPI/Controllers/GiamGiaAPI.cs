using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaAPI : ControllerBase
    {
        private readonly ILogger<GiamGiaAPI> _logger;
        private readonly IGiamGiaService _giamgiaService;
        public GiamGiaAPI(ILogger<GiamGiaAPI> logger, IGiamGiaService giamGiaService)
        {
            _logger = logger;
            _giamgiaService = giamGiaService;
        }
        // GET: api/<GiamGiaAPI>
        [HttpGet]
        public async Task<List<GiamGiaVM>> GetAllGiamGiaVM()
        {
            return await _giamgiaService.GetAll();
        }

        // GET api/<GiamGiaAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GiamGiaAPI>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{

        //}

        // PUT api/<GiamGiaAPI>/5
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Them([FromForm] GiamGiaVM gg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var giamgiaId = await _giamgiaService.Create(gg);
            if (giamgiaId == 0)
                return BadRequest();
            var giamgia = await _giamgiaService.GetById(giamgiaId);
            return CreatedAtAction(nameof(GetById), new { id = giamgiaId }, giamgia);
        }
        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] GiamGiaVM gg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            gg.Id = id;
            var affectedResult = await _giamgiaService.Edit(gg);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
        [HttpGet("giamgia/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var giamgia = await _giamgiaService.GetById(id);
            if (giamgia == null)
            {
                return BadRequest("Can't find giamgia");
            }
            return Ok(giamgia);
        }

        // DELETE api/<GiamGiaAPI>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _giamgiaService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
