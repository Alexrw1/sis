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
    public class TypeNumbersController : ControllerBase
    {
        private readonly HotelBaseContext _context;

        public TypeNumbersController(HotelBaseContext context)
        {
            _context = context;
        }

        // GET: api/TypeNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeNumber>>> GetTypeNumbers()
        {
            return await _context.TypeNumbers.ToListAsync();
        }

        // GET: api/TypeNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeNumber>> GetTypeNumber(int id)
        {
            var typeNumber = await _context.TypeNumbers.FindAsync(id);

            if (typeNumber == null)
            {
                return NotFound();
            }

            return typeNumber;
        }

        // PUT: api/TypeNumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeNumber(int id, TypeNumber typeNumber)
        {
            if (id != typeNumber.IdTypeNumber)
            {
                return BadRequest();
            }

            _context.Entry(typeNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeNumberExists(id))
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

        // POST: api/TypeNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeNumber>> PostTypeNumber(TypeNumber typeNumber)
        {
            _context.TypeNumbers.Add(typeNumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeNumber", new { id = typeNumber.IdTypeNumber }, typeNumber);
        }

        // DELETE: api/TypeNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeNumber(int id)
        {
            var typeNumber = await _context.TypeNumbers.FindAsync(id);
            if (typeNumber == null)
            {
                return NotFound();
            }

            _context.TypeNumbers.Remove(typeNumber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeNumberExists(int id)
        {
            return _context.TypeNumbers.Any(e => e.IdTypeNumber == id);
        }
    }
}
