using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocationTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationTrackerContext _context;

        public LocationController(ILocationTrackerContext context)
        {
            _context = context;
        }

        [HttpGet("{phone}")]
        public async Task<IActionResult> GetAll(string phone)
        {
            var locations = await _context.Locations
                .Where(l => l.Phone == phone)
                .OrderByDescending(l => l.Date)
                .ToListAsync();

            dynamic result = new System.Dynamic.ExpandoObject();
            result.count = locations.Count;
            result.locations = locations;

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{phone}")]
        public async Task<IActionResult> Delete(string phone)
        {
            var locations = await _context.Locations
                .Where(l => l.Phone == phone)
                .ToListAsync();
            _context.Locations.RemoveRange(locations);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}