using System.Linq;
using System.Threading.Tasks;
using Blazor.Login.Server.Data;
using Blazor.Login.Server.Models;
using Blazor.Login.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blazor.Login.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DeveloperController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var developers = await _context.Developers.Select(developer => new DeveloperDto
            {
                Email = developer.Email,
                Experience = developer.Experience,
                FirstName = developer.FirstName,
                LastName = developer.LastName,
                Id = developer.Id
            }).ToListAsync();
            return Ok(developers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var developer = await _context.Developers.FirstOrDefaultAsync(a => a.Id == id);

            if (developer is null)
            {
                var developerDto = new DeveloperDto
                {
                    Email = developer.Email,
                    Experience = developer.Experience,
                    FirstName = developer.FirstName,
                    LastName = developer.LastName,
                    Id = id,
                };

                return Ok(developerDto);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Post(DeveloperDto developerDto)
        {
            Developer developer = await _context.Developers.FirstOrDefaultAsync(x => x.Id == developerDto.Id);

            if (developer is null)
            {
                developer = new Developer
                {
                    Email = developerDto.Email,
                    Experience = developerDto.Experience,
                    FirstName = developerDto.FirstName,
                    LastName = developerDto.LastName
                };
                _context.Add(developer);
                await _context.SaveChangesAsync();
                return Ok(developer.Id);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(DeveloperDto developerDto)
        {
            Developer developer = await _context.Developers.FirstOrDefaultAsync(x => x.Id == developerDto.Id);

            if (developer is null)
            {
                developer.Email = developerDto.Email;
                developer.Experience = developerDto.Experience;
                developer.FirstName = developerDto.FirstName;
                developer.LastName = developerDto.LastName;
                _context.Entry(developer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var developer = new Developer { Id = id };
            _context.Remove(developer);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}