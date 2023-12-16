using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Persistence
{
    public interface IGeralPersistence
    {
                /// **********************************
        /// <summary>*************************
        /// GERAL*****************************
        /// </summary>************************
        /// <typeparam name="T"></typeparam>**
        /// <param name="entity"></param>*****
        /// ***********************************
        
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
       void Delete<T>(T entity) where T: class;
       void DeleteRange<T>(T[] entity) where T: class;
       Task<bool> SaveChangedAsync();
        
    }
}