using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProLivros.Persistence;
using ProLivros.Domain;
using ProLivros.Application;

namespace ProLivros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        // GET: api/Livro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            try
            {
                var livros = await _livroService.GetAllLivrosAsync();
                if (_livroService.GetAllLivrosAsync() == null)
                {
                    return NotFound("Nenhum Livro encontrado.");
                }
                return Ok(livros);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar carregar os Livros. Erro: {ex.Message}");
            }
        }

        // GET: api/Livro/{parametro}
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            try
            {
                var livros = await _livroService.GetLivroByIdAsync(id);
                if (_livroService.GetAllLivrosAsync() == null)
                    return NotFound("Nenhum Livro encontrado.");
                return Ok(livros);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar carregar os Livros. Erro: {ex.Message}");
            }
        }


        [HttpGet("{titulo}/titulo")]
        public async Task<ActionResult<Livro>> GetLivro(string titulo)
        {
            try
            {
                var livros = await _livroService.GetAllLivrosByTituloAsync(titulo);
                if (livros == null)
                {
                    return NotFound("Nenhum Livro encontrado.");
                }
                return Ok(livros);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar carregar os Livros. Erro: {ex.Message}");
            }
        }

        // POST: api/Livro
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            try
            {
                var _livro = await _livroService.AddLivro(livro);
                if (_livro == null)
                {
                    return BadRequest("Erro ao adicionar livro.");
                }
                return Ok(_livro);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adiicionar Livro . Erro: {ex.Message}");
            }
        }

        // PUT: api/Livro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            try
            {
                var _livro = await _livroService.UpdateLivro(id, livro);
                if (_livro == null)
                {
                    return BadRequest("Erro ao atualizar livro.");
                }
                return Ok(_livro);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar Livro . Erro: {ex.Message}");
            }
        }


        // DELETE: api/Livro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            try
            {
                return await _livroService.DeleteLivro(id) ? 
                    Ok("Livro excluído com sucesso!") : 
                    BadRequest("Erro ao excluir Livro.");
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar excluir Livro . Erro: {ex.Message}");
            }
        }
    }
}
