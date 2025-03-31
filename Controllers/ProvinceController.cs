using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourWebApi.Data;
using TourWebApi.DTOs;
using TourWebApi.Services;

namespace TourWebApi.Controllers
{
    [Route("api/provinces")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        // Lấy danh sách Province dưới dạng DTO
         // Lấy danh sách Province dưới dạng DTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProvinceDTO>>> GetProvinces()
        {
            var provinces = await _provinceService.GetAllProvincesAsync();
            return Ok(provinces);
        }
        // Lấy Province theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ProvinceDTO>> GetProvince(int id)
        {
            var province = await _provinceService.GetProvinceByIdAsync(id);
            if (province == null)
                return NotFound();
            return Ok(province);
        }

        // Thêm mới Province
        [HttpPost]
        public async Task<ActionResult<ProvinceDTO>> CreateProvince(ProvinceDTO provinceDto)
        {
            var newProvince = await _provinceService.AddProvinceAsync(provinceDto);
            return CreatedAtAction(nameof(GetProvince), new { id = newProvince.Id }, newProvince);
        }

        // Cập nhật Province
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvince(int id, ProvinceDTO provinceDto)
        {
            var updatedProvince = await _provinceService.UpdateProvinceAsync(id, provinceDto);
            if (updatedProvince == null)
                return NotFound();
            return NoContent();
        }

        // Xóa Province
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvince(int id)
        {
            var result = await _provinceService.DeleteProvinceAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    
    }
}
