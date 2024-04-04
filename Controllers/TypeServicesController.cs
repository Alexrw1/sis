using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAUTHandJWT.Models;

namespace OAUTHandJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeServicesController : ControllerBase
    {
        private readonly HotelBaseContext _context;

        public TypeServicesController(HotelBaseContext context)
        {
            _context = context;
        }

        // GET: api/TypeServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeService>>> GetTypeServices()
        {
            return await _context.TypeServices.ToListAsync();
        }

        // GET: api/TypeServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeService>> GetTypeService(int id)
        {
            var typeService = await _context.TypeServices.FindAsync(id);

            if (typeService == null)
            {
                return NotFound();
            }

            return typeService;
        }

        // PUT: api/TypeServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeService(int id, TypeService typeService)
        {
            if (id != typeService.IdTypeService)
            {
                return BadRequest();
            }

            _context.Entry(typeService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TypeServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeService>> PostTypeService(TypeService typeService)
        {
            _context.TypeServices.Add(typeService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeService", new { id = typeService.IdTypeService }, typeService);
        }

        // DELETE: api/TypeServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeService(int id)
        {
            var typeService = await _context.TypeServices.FindAsync(id);
            if (typeService == null)
            {
                return NotFound();
            }

            _context.TypeServices.Remove(typeService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeServiceExists(int id)
        {
            return _context.TypeServices.Any(e => e.IdTypeService == id);
        }
    }
}
