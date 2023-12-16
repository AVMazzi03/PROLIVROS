using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProLivros.Domain;

namespace ProLivros.Persistence
{
    public class AutorPersistence : IAutorPersistence
    {
        private readonly ProLivrosContext _context;

        public AutorPersistence(ProLivrosContext context)
        {
            _context = context;
        }
# region AUTOR

        public async Task<Autor[]> GetAllAutoresAsync()
        {
            IQueryable<Autor> query = _context.Autores;

            query = query
                    .Include(lau => lau.LivroAutor)
                    .ThenInclude(lau => lau.Livro);

            query.OrderBy(l => l.Nome);
            return await query.ToArrayAsync();
        }
        public async Task<Autor[]> GetAllAutoresByNomeAsync(string nome)
        {
            IQueryable<Autor> query = _context.Autores;

            query = query
                    .Include(lau => lau.LivroAutor)
                    .ThenInclude(lau => lau.Livro);

            query.OrderBy(l => l.Nome)
                     .Where(au => au.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Autor> GetAutorByIdAsync(int autorId)
        {
            IQueryable<Autor> query = _context.Autores;

            query = query
                .Include(autor => autor.LivroAutor)
                .ThenInclude(lautor => lautor.Livro);


            query.OrderBy(au => au.Nome)
                     .Where(autor => autor.CodAu.Equals(autorId));

            return await query.FirstOrDefaultAsync();
        }
        #endregion
    }
}