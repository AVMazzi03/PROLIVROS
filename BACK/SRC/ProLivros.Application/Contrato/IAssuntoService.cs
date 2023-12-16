using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProLivros.Domain;

namespace ProLivros.Application
{
    public interface IAssuntoService
    {
        Task<Assunto> AddAssunto(Assunto model);
        Task<Assunto> UpdateAssunto(int assuntoId, Assunto model);
        Task<bool> DeleteAssunto(int assuntoId);

        Task<Assunto[]> GetAllAssuntosAsync();
        Task<Assunto[]> GetAllAssuntosByDescricaoAsync(string descricao);
        Task<Assunto> GetAssuntoByIdAsync(int assuntoId);
    }
}