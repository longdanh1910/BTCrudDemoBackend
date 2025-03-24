using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourWebApi.Data;
using TourWebApi.DTOs;

namespace TourWebApi.Controllers
{
    [Route("api/provinces")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProvinceController(AppDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách Province dưới dạng DTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProvinceDTO>>> GetProvinces()
        {
            var provinces = await _context.Provinces
                .Select(p => new ProvinceDTO { Id = p.Id, Name = p.Name })
                .ToListAsync();
            return Ok(provinces);
        }
    }
}
