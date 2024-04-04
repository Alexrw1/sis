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
    public class ClassNumbersController : ControllerBase
    {
        private readonly HotelBaseContext _context;

        public ClassNumbersController(HotelBaseContext context)
        {
            _context = context;
        }

        // GET: api/ClassNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassNumber>>> GetClassNumbers()
        {
            return await _context.ClassNumbers.ToListAsync();
        }

        // GET: api/ClassNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassNumber>> GetClassNumber(int id)
        {
            var classNumber = await _context.ClassNumbers.FindAsync(id);

            if (classNumber == null)
            {
                return NotFound();
            }

            return classNumber;
        }

        // PUT: api/ClassNumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassNumber(int id, ClassNumber classNumber)
        {
            if (id != classNumber.IdClassNumber)
            {
                return BadRequest();
            }

            _context.Entry(classNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassNumberExists(id))
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

        // POST: api/ClassNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClassNumber>> PostClassNumber(ClassNumber classNumber)
        {
            _context.ClassNumbers.Add(classNumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassNumber", new { id = classNumber.IdClassNumber }, classNumber);
        }

        // DELETE: api/ClassNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClassNumber(int id)
        {
            var classNumber = await _context.ClassNumbers.FindAsync(id);
            if (classNumber == null)
            {
                return NotFound();
            }

            _context.ClassNumbers.Remove(classNumber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassNumberExists(int id)
        {
            return _context.ClassNumbers.Any(e => e.IdClassNumber == id);
        }
    }
}
