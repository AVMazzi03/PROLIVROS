using ProLivros.Application;
using ProLivros.Domain;
using ProLivros.Persistence;

namespace prolivros.application.Service
{
    internal class AutorService : IAutorService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IAutorPersistence _autorPersistence;
        public AutorService(IGeralPersistence geralPersistence, IAutorPersistence autorPersistence)
        {
            _autorPersistence = autorPersistence;
            _geralPersistence = geralPersistence;

        }
        public async Task<Autor> AddAutor(Autor model)
        {
            try
            {
                _geralPersistence.Add<Autor>(model);

                if (await _geralPersistence.SaveChangedAsync())
                {
                    return await _autorPersistence.GetAutorByIdAsync(model.CodAu);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Adicionar Autor! " + ex.Message);
            }
        }
        public async Task<Autor> UpdateAutor(int autorId, Autor model)
        {
            try
            {
                var autor = await _autorPersistence.GetAutorByIdAsync(autorId);
                if (autor == null) return null;

                model.CodAu = autorId;

                _geralPersistence.Update(model);
                if (await _geralPersistence.SaveChangedAsync())
                {
                    return await _autorPersistence.GetAutorByIdAsync(model.CodAu);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar Autor! " + ex.Message);
            }
        }

        public async Task<bool> DeleteAutor(int autorId)
        {
            try
            {
                var autor = await _autorPersistence.GetAutorByIdAsync(autorId);
                if (autor == null) throw new Exception("Não foi possível excluir autor.");

                _geralPersistence.Delete<Autor>(autor);
                return await _geralPersistence.SaveChangedAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir Autor! " + ex.Message);
            }
        }

        public async Task<Autor[]> GetAllAutoresAsync()
        {
            try
            {
                var autores = await _autorPersistence.GetAllAutoresAsync();
                if (autores == null) return null;

                return autores;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public async Task<Autor[]> GetAllAutoresByNomeAsync(string nome)
        {
            try
            {
                var autores = await _autorPersistence.GetAllAutoresByNomeAsync(nome);
                if (autores == null) return null;

                return autores;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Autor> GetAutorByIdAsync(int autorId)
        {
            try
            {
                var autor = await _autorPersistence.GetAutorByIdAsync(autorId);
                if (autor == null) return null;

                return autor;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
