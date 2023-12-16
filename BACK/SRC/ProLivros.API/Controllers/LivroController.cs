using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProLivros.Persistence;
using ProLivros.Domain;

namespace ProLivros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ProLivrosContext _context;

        public LivroController(ProLivrosContext context)
        {
            _context = context;
        }

        // GET: api/Livro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
          if (_context.Livros == null)
          {
              return NotFound();
          }
            return await _context.Livros
            .ToListAsync();
        }

        // GET: api/Livro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int? id)
        {
          if (_context.Livros == null)
          {
              return NotFound();
          }
            var livro = await _context.Livros.FindAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        // PUT: api/Livro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int? id, Livro livro)
        {
            if (id != livro.Codl)
            {
                return BadRequest();
            }

            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
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

        // POST: api/Livro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
          if (_context.Livros == null)
          {
              return Problem("Entity set 'ProLivrosAPIContext.Livros'  is null.");
          }
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivro", new { id = livro.Codl }, livro);
        }

        // DELETE: api/Livro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int? id)
        {
            if (_context.Livros == null)
            {
                return NotFound();
            }
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LivroExists(int? id)
        {
            return (_context.Livros?.Any(e => e.Codl == id)).GetValueOrDefault();
        }
    }
}
