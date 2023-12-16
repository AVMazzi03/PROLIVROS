using ProLivros.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Persistence
{
    public interface IAssuntoPersistence
    {
        /// **************************************
        /// <summary>*****************************
        /// ASSUNTOS******************************
        /// </summary>****************************
        /// <param name="descricao"></param>******
        /// <param name="includeLivro"></param>***
        /// <param name="assuntId"></param>*******
        /// <returns></returns>*******************
        /// **************************************

        Task<Assunto[]> GetAllAssuntosAsync();
        Task<Assunto[]> GetAllAssuntosByDescricaoAsync(string descricao);
        Task<Assunto> GetAssuntoByIdAsync(int assuntoId);
    }
}