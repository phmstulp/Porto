﻿using System;
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
    public class ViagemsController : ControllerBase
    {
        private readonly portodbContext _context;

        public ViagemsController(portodbContext context)
        {
            _context = context;
        }

        // GET: api/Viagems
        [HttpGet]
        public IEnumerable<Viagem> GetViagem()
        {
            return _context.Viagem;
        }

        // GET: api/Viagems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetViagem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var viagem = await _context.Viagem.FindAsync(id);

            if (viagem == null)
            {
                return NotFound();
            }

            return Ok(viagem);
        }

        // PUT: api/Viagems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutViagem([FromRoute] int id, [FromBody] Viagem viagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viagem.ViagemId)
            {
                return BadRequest();
            }

            _context.Entry(viagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViagemExists(id))
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

        // POST: api/Viagems
        [HttpPost]
        public async Task<IActionResult> PostViagem([FromBody] Viagem viagem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Viagem.Add(viagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetViagem", new { id = viagem.ViagemId }, viagem);
        }

        // DELETE: api/Viagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteViagem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var viagem = await _context.Viagem.FindAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }

            _context.Viagem.Remove(viagem);
            await _context.SaveChangesAsync();

            return Ok(viagem);
        }

        private bool ViagemExists(int id)
        {
            return _context.Viagem.Any(e => e.ViagemId == id);
        }
    }
}