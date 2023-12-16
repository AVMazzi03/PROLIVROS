using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProLivros.Persistence;
using ProLivros.Domain;

namespace ProLivros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntoController : ControllerBase
    {
        private readonly ProLivrosContext _context;

        public AssuntoController(ProLivrosContext context)
        {
            _context = context;
        }

        // GET: api/Assunto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assunto>>> GetAssuntos()
        {
          if (_context.Assuntos == null)
          {
              return NotFound();
          }
            return await _context.Assuntos.ToListAsync();
        }

        // GET: api/Assunto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assunto>> GetAssunto(int? id)
        {
          if (_context.Assuntos == null)
          {
              return NotFound();
          }
            var assunto = await _context.Assuntos.FindAsync(id);

            if (assunto == null)
            {
                return NotFound();
            }

            return assunto;
        }

        // PUT: api/Assunto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssunto(int? id, Assunto assunto)
        {
            if (id != assunto.CodAs)
            {
                return BadRequest();
            }

            _context.Entry(assunto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssuntoExists(id))
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

        // POST: api/Assunto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Assunto>> PostAssunto(Assunto assunto)
        {
          if (_context.Assuntos == null)
          {
              return Problem("Entity set 'ProLivrosAPIContext.Assuntos'  is null.");
          }
            _context.Assuntos.Add(assunto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssunto", new { id = assunto.CodAs }, assunto);
        }

        // DELETE: api/Assunto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssunto(int? id)
        {
            if (_context.Assuntos == null)
            {
                return NotFound();
            }
            var assunto = await _context.Assuntos.FindAsync(id);
            if (assunto == null)
            {
                return NotFound();
            }

            _context.Assuntos.Remove(assunto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AssuntoExists(int? id)
        {
            return (_context.Assuntos?.Any(e => e.CodAs == id)).GetValueOrDefault();
        }
    }
}
