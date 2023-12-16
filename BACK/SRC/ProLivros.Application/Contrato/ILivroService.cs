using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using ProLivros.Domain;

namespace ProLivros.Application
{
    public interface ILivroService
    {
        Task<Livro> AddLivro(Livro model);
        Task<Livro> UpdateLivro(int livroId, Livro model);
        Task<bool> DeleteLivro(int livroId);

        Task<Livro[]> GetAllLivrosAsync();
        Task<Livro[]> GetAllLivrosByTituloAsync(string titulo);
        Task<Livro> GetLivroByIdAsync(int livroId);

    }
}