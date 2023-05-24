using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

namespace Shop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KichCoAPI : ControllerBase
    {
        private readonly ILogger<KichCoAPI> _logger;
        private readonly IKichCoService _kichCoService;

        public KichCoAPI(ILogger<KichCoAPI> logger, IKichCoService kichCoService)
        {
            _logger = logger;
            _kichCoService = kichCoService;
        }

        // GET: api/KichCoAPI
        [HttpGet]
        public async Task<List<KichCoVM>> GetAllKichCoVM()
        {

            return await _kichCoService.GetAllKichCo();
        }

        // GET: api/<KichCoAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/KichCoAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        // POST: api/KichCoAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> Them([FromForm] KichCoVM kc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("ModelState");
            }
            var kichcoId = await _kichCoService.Them(kc);
            if (kichcoId == 0)
                return BadRequest();
            var kichco = await _kichCoService.GetById(kichcoId);
            return CreatedAtAction(nameof(GetById), new { id = kichcoId }, kichco);
        }


        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] KichCoVM kc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            kc.Id = id;
            var affectedResult = await _kichCoService.Sua(kc);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }


        [HttpGet("kichco/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var kichco = await _kichCoService.GetById(id);
            if (kichco == null)
            {
                return BadRequest("Can't find kichco");
            }
            return Ok(kichco);
        }

        // DELETE: api/KichCoAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _kichCoService.Xoa(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        //private bool KichCoExists(int id)
        //{
        //    return (_context.KichCos?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
