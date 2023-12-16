using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProLivros.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProLivros.Persistence
{
    public class ProLivrosPersistence : IProLivrosPersistence
    {
        private readonly ProLivrosContext _context;

        public ProLivrosPersistence(ProLivrosContext context)
        {
            _context = context;
        }

        #region GERAL
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangedAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
        #endregion
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
        public async Task<Livro> GetlivroByIdAsync(int livroId)
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


        #region ASSUNTOS
        public async Task<Assunto[]> GetAllAssuntosAsync()
        {
            IQueryable<Assunto> query = _context.Assuntos;

            query = query
                    .Include(las => las.LivroAssunto)
                    .ThenInclude(las => las.Livro);

            query.OrderBy(l => l.Descricao);
            return await query.ToArrayAsync();
        }
        public async Task<Assunto[]> GetAllAssuntosByDescricaoAsync(string descricao)
        {
            IQueryable<Assunto> query = _context.Assuntos;

            query = query
                    .Include(las => las.LivroAssunto)
                    .ThenInclude(las => las.Livro);

            query.OrderBy(l => l.Descricao)
                 .Where(l => l.Descricao.ToLower().Contains(descricao.ToLower()));
            return await query.ToArrayAsync();
        }


        public async Task<Assunto> GetAssuntoByIdAsync(int assuntoId)
        {
            IQueryable<Assunto> query = _context.Assuntos;

            query = query
                .Include(assunto => assunto.LivroAssunto)
                .ThenInclude(lassunto => lassunto.Livro);

            query.OrderBy(l => l.Descricao)
                 .Where(assunto => assunto.CodAs.Equals(assuntoId));
            return await query.FirstOrDefaultAsync();
        }
        #endregion




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
        public async Task<Autor[]> GetAllAutoresByNomeAsync(string Nome)
        {
            IQueryable<Autor> query = _context.Autores;

            query = query
                    .Include(lau => lau.LivroAutor)
                    .ThenInclude(lau => lau.Livro);

            query.OrderBy(l => l.Nome)
                     .Where(au => au.Nome.ToLower().Contains(Nome.ToLower()));
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