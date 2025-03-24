using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourWebApi.Models;
using TourWebApi.Services;

namespace TourWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> GetAllTours()
        {
            return Ok(await _tourService.GetAllToursAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetTourById(int id)
        {
            var tour = await _tourService.GetTourByIdAsync(id);
            if (tour == null)
                return NotFound();
            return Ok(tour);
        }

        [HttpPost]
        public async Task<ActionResult> AddTour(Tour tour)
        {
            await _tourService.AddTourAsync(tour);
            return CreatedAtAction(nameof(GetTourById), new { id = tour.Id }, tour);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTour(int id, Tour tour)
        {
            if (id != tour.Id)
                return BadRequest();

            await _tourService.UpdateTourAsync(tour);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTour(int id)
        {
            await _tourService.DeleteTourAsync(id);
            return NoContent();
        }
    }
}
