using ProLivros.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Persistence.Interfaces
{
    public interface IAutorPersistence
    {
                /// **************************************
        /// <summary>*****************************
        /// AUTORES*******************************
        /// </summary>****************************
        /// <param name="Nome"></param>***********
        /// <param name="includeLivro"></param>***
        /// <param name="idAutor"></param>********
        /// <returns></returns>*******************
        /// **************************************
        Task<Autor[]> GetAllAutoresAsync();
        Task<Autor[]> GetAllAutoresByNomeAsync(string Nome);
        Task<Autor> GetAutorByIdAsync(int autorId);
    }
}