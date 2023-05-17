using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.Services;
using Shop.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChucVuAPI : ControllerBase
{
    private readonly ILogger<ChucVuAPI> _logger;
    private readonly IChucVuService _chucVuService;

    public ChucVuAPI(ILogger<ChucVuAPI> logger, IChucVuService chucVuService)
    {
        _logger = logger;
        _chucVuService = chucVuService;
    }

    // GET: api/<ChucVuAPI>
    [HttpGet]
    public async Task<List<ChucVuVM>> GetAllChucVuVM()
    {
        return await _chucVuService.GetAllChucVu();
    }

    // GET api/<ChucVuAPI>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ChucVuAPI>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ChucVuAPI>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ChucVuAPI>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}