using Microsoft.EntityFrameworkCore;
using ProLivros.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Persistence
{
    public class AssuntoPersistence : IAssuntoPersistence
    {
        private readonly ProLivrosContext _context;

        public AssuntoPersistence(ProLivrosContext context)
        {
            _context = context;
        }
         
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

    }
}