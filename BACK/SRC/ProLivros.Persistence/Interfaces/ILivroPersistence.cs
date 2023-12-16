using ProLivros.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Persistence
{
    public interface ILivroPersistence
    {      
        /// **************************************
        /// <summary>*****************************
        /// LIVROS******************************
        /// </summary>****************************
        /// <param name="descricao"></param>******
        /// <param name="includeLivro"></param>***
        /// <param name="assuntId"></param>*******
        /// <returns></returns>*******************
        /// **************************************

        Task<Livro[]> GetAllLivrosAsync();
        Task<Livro[]> GetAllLivrosByTituloAsync(string titulo);
        Task<Livro> GetLivroByIdAsync(int livroId);

    }
}