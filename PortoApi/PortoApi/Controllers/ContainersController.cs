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
    public class ContainersController : ControllerBase
    {
        private readonly portodbContext _context;

        public ContainersController(portodbContext context)
        {
            _context = context;
        }

        // GET: api/Containers
        [HttpGet]
        public IEnumerable<Container> GetContainer()
        {
            return _context.Container;
        }

        // GET: api/Containers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContainer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var container = await _context.Container.FindAsync(id);

            if (container == null)
            {
                return NotFound();
            }

            return Ok(container);
        }

        // PUT: api/Containers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContainer([FromRoute] int id, [FromBody] Container container)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != container.ContainerId)
            {
                return BadRequest();
            }
            container.DtUpdate = DateTime.Now;

            _context.Entry(container).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(container);
        }

        // POST: api/Containers
        [HttpPost]
        public async Task<IActionResult> PostContainer([FromBody] Container container)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            container.DtRecord = DateTime.Now;
            container.DtUpdate = DateTime.Now;

            _context.Container.Add(container);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContainer", new { id = container.ContainerId }, container);
        }

        // DELETE: api/Containers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContainer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var container = await _context.Container.FindAsync(id);
            if (container == null)
            {
                return NotFound();
            }

            _context.Container.Remove(container);
            await _context.SaveChangesAsync();

            return Ok(container);
        }

        private bool ContainerExists(int id)
        {
            return _context.Container.Any(e => e.ContainerId == id);
        }
    }
}
