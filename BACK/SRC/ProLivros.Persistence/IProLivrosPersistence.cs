using ProLivros.Domain;

namespace ProLivros.Persistence
{
    public interface IProLivrosPersistence
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

     
        /// ****************************************
        /// <summary>*******************************
        /// LIVROS**********************************
        /// </summary>******************************
        /// <param name="titulo"></param>***********
        /// <param name="includeAssunto"></param>***
        /// <param name="icludeAutor"></param>******
        /// <param name="idLivro"></param>**********
        /// <returns></returns>*********************
        /// ****************************************

        Task<Livro[]> GetAllLivrosAsync();
        Task<Livro[]> GetAllLivrosByTituloAsync(string titulo);
        Task<Livro> GetlivroByIdAsync(int livroId);

      
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