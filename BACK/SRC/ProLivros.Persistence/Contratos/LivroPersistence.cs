using Microsoft.EntityFrameworkCore;
using ProLivros.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Persistence
{
    public class LivroPersistence : ILivroPersistence
    {
        
        private readonly ProLivrosContext _context;

        public LivroPersistence(ProLivrosContext context)
        {
            _context = context;
        }

        #region LIVROS
        public async Task<Livro[]> GetAllLivrosAsync()
        {
            IQueryable<Livro> query = _context.Livros;
            query = query
                    .Include(l => l.LivroAssunto)
                    .ThenInclude(las => las.Assunto);
            query = query
                    .Include(l => l.LivroAutor)
                    .ThenInclude(lau => lau.Autor);

            query.OrderBy(l => l.Titulo);
            return await query.ToArrayAsync();
        }

        public async Task<Livro[]> GetAllLivrosByTituloAsync(string titulo)
        {
            IQueryable<Livro> query = _context.Livros;
            query = query
                    .Include(l => l.LivroAssunto)
                    .ThenInclude(las => las.Assunto);
            query = query
                    .Include(l => l.LivroAutor)
                    .ThenInclude(lau => lau.Autor);

            query.OrderBy(l => l.Titulo)
                    .Where(l => l.Titulo.ToLower().Contains(titulo.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Livro> GetLivroByIdAsync(int livroId)
        {
            IQueryable<Livro> query = _context.Livros;
            query = query
                    .Include(l => l.LivroAssunto)
                    .ThenInclude(las => las.Assunto);
            query = query
                    .Include(l => l.LivroAutor)
                    .ThenInclude(lau => lau.Autor);

            query.OrderBy(l => l.Titulo)
                    .Where(l => l.Codl.Equals(livroId));
            return await query.FirstOrDefaultAsync();
        }
        #endregion
    }
}