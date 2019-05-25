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
    public class ItemViagemsController : ControllerBase
    {
        private readonly portodbContext _context;

        public ItemViagemsController(portodbContext context)
        {
            _context = context;
        }

        // GET: api/ItemViagems
        [HttpGet]
        public IEnumerable<ItemViagem> GetItemViagem()
        {
            return _context.ItemViagem;
        }

        // GET: api/ItemViagems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemViagem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemViagem = await _context.ItemViagem.FindAsync(id);

            if (itemViagem == null)
            {
                return NotFound();
            }

            return Ok(itemViagem);
        }

        // PUT: api/ItemViagems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemViagem([FromRoute] int id, [FromBody] ItemViagem itemViagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemViagem.ItemViagemId)
            {
                return BadRequest();
            }

            _context.Entry(itemViagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemViagemExists(id))
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

        // POST: api/ItemViagems
        [HttpPost]
        public async Task<IActionResult> PostItemViagem([FromBody] ItemViagem itemViagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ItemViagem.Add(itemViagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemViagem", new { id = itemViagem.ItemViagemId }, itemViagem);
        }

        // DELETE: api/ItemViagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemViagem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemViagem = await _context.ItemViagem.FindAsync(id);
            if (itemViagem == null)
            {
                return NotFound();
            }

            _context.ItemViagem.Remove(itemViagem);
            await _context.SaveChangesAsync();

            return Ok(itemViagem);
        }

        private bool ItemViagemExists(int id)
        {
            return _context.ItemViagem.Any(e => e.ItemViagemId == id);
        }
    }
}