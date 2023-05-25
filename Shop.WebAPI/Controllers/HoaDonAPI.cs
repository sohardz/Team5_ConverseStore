﻿using Microsoft.AspNetCore.Mvc;
using Shop.Application.IServices;
using Shop.Application.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonAPI : ControllerBase
    {
        private readonly ILogger<HoaDonAPI> _logger;
        private readonly IHoaDonServices _hoaDonServices;

        public HoaDonAPI(ILogger<HoaDonAPI> logger, IHoaDonServices hoaDonServices)
        {
            _logger = logger;
            _hoaDonServices = hoaDonServices;
        }

        [HttpGet]
        public async Task<List<HoaDonVM>> GetAllGioHangVM()
        {
            return await _hoaDonServices.GetAll();
        }

        [HttpGet("sanpham/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hoadon = await _hoaDonServices.GetById(id);
            if (hoadon == null)
            {
                return BadRequest("Không thể tìm sản phẩm");
            }
            return Ok(hoadon);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] HoaDonVM request)
        {
            int x = request.Id;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hoadonId = await _hoaDonServices.Create(request);
            if (hoadonId == 0)
                return BadRequest();
            var sanpham = await _hoaDonServices.GetById(hoadonId);
            return CreatedAtAction(nameof(GetById), new { id = hoadonId }, sanpham);
        }

        [HttpPut("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] HoaDonVM p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            p.Id = id;
            var affectedResult = await _hoaDonServices.Edit(p);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var affectedResult = await _hoaDonServices.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}