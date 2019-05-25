using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortoApi.Models;

namespace PortoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaviosController : ControllerBase
    {
        private readonly portodbContext _context;

        public NaviosController(portodbContext context)
        {
            _context = context;
        }

        // GET: api/Navios
        [HttpGet]
        public IEnumerable<Navio> GetNavio()
        {
            return _context.Navio;
        }

        // GET: api/Navios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNavio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var navio = await _context.Navio.FindAsync(id);

            if (navio == null)
            {
                return NotFound();
            }

            return Ok(navio);
        }

        // PUT: api/Navios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNavio([FromRoute] int id, [FromBody] Navio navio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != navio.NavioId)
            {
                return BadRequest();
            }

            _context.Entry(navio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NavioExists(id))
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

        // POST: api/Navios
        [HttpPost]
        public async Task<IActionResult> PostNavio([FromBody] Navio navio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Navio.Add(navio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNavio", new { id = navio.NavioId }, navio);
        }

        // DELETE: api/Navios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNavio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var navio = await _context.Navio.FindAsync(id);
            if (navio == null)
            {
                return NotFound();
            }

            _context.Navio.Remove(navio);
            await _context.SaveChangesAsync();

            return Ok(navio);
        }

        private bool NavioExists(int id)
        {
            return _context.Navio.Any(e => e.NavioId == id);
        }
    }
}