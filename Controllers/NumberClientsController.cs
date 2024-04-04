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
    public class NumberClientsController : ControllerBase
    {
        private readonly HotelBaseContext _context;

        public NumberClientsController(HotelBaseContext context)
        {
            _context = context;
        }

        // GET: api/NumberClients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NumberClient>>> GetNumberClients()
        {
            return await _context.NumberClients.ToListAsync();
        }

        // GET: api/NumberClients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NumberClient>> GetNumberClient(int id)
        {
            var numberClient = await _context.NumberClients.FindAsync(id);

            if (numberClient == null)
            {
                return NotFound();
            }

            return numberClient;
        }

        // PUT: api/NumberClients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumberClient(int id, NumberClient numberClient)
        {
            if (id != numberClient.IdNumberClient)
            {
                return BadRequest();
            }

            _context.Entry(numberClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NumberClientExists(id))
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

        // POST: api/NumberClients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NumberClient>> PostNumberClient(NumberClient numberClient)
        {
            _context.NumberClients.Add(numberClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNumberClient", new { id = numberClient.IdNumberClient }, numberClient);
        }

        // DELETE: api/NumberClients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNumberClient(int id)
        {
            var numberClient = await _context.NumberClients.FindAsync(id);
            if (numberClient == null)
            {
                return NotFound();
            }

            _context.NumberClients.Remove(numberClient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NumberClientExists(int id)
        {
            return _context.NumberClients.Any(e => e.IdNumberClient == id);
        }
    }
}
