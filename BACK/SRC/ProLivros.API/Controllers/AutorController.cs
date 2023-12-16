using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProLivros.Persistence;
using ProLivros.Domain;

namespace ProLivros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly ProLivrosContext _context;

        public AutorController(ProLivrosContext context)
        {
            _context = context;
        }

        // GET: api/Autor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
          if (_context.Autores == null)
          {
              return NotFound();
          }
            return await _context.Autores.ToListAsync();
        }

        // GET: api/Autor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int? id)
        {
          if (_context.Autores == null)
          {
              return NotFound();
          }
            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // PUT: api/Autor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int? id, Autor autor)
        {
            if (id != autor.CodAu)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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

        // POST: api/Autor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
          if (_context.Autores == null)
          {
              return Problem("Entity set 'ProLivrosAPIContext.Autores'  is null.");
          }
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.CodAu }, autor);
        }

        // DELETE: api/Autor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int? id)
        {
            if (_context.Autores == null)
            {
                return NotFound();
            }
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutorExists(int? id)
        {
            return (_context.Autores?.Any(e => e.CodAu == id)).GetValueOrDefault();
        }
    }
}
