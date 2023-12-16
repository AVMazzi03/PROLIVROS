using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        
        private readonly ProLivrosContext _context;

        public GeralPersistence(ProLivrosContext context)
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
    }
}