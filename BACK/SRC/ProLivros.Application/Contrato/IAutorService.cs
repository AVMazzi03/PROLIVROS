using ProLivros.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Application
{
    public interface IAutorService
    {
        Task<Autor> AddAutor(Autor model);
        Task<Autor> UpdateAutor(int autorId, Autor model);
        Task<bool> DeleteAutor(int autorId);

        Task<Autor[]> GetAllAutoresAsync();
        Task<Autor[]> GetAllAutoresByNomeAsync(string Nome);
        Task<Autor> GetAutorByIdAsync(int autorId);
    }
}