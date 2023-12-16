using ProLivros.Domain;
using ProLivros.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLivros.Application
{
    public class LivroService : ILivroService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly ILivroPersistence _livroPersistence;

        public LivroService(IGeralPersistence geralPersistence, ILivroPersistence livroPersistence)
        {
            _geralPersistence = geralPersistence;
            _livroPersistence = livroPersistence;
        }
        public async Task<Livro> AddLivro(Livro model)
        {
            try
            {
                _geralPersistence.Add<Livro>(model);

                if (await _geralPersistence.SaveChangedAsync()) 
                {
                    return await _livroPersistence.GetLivroByIdAsync(model.Codl);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Adicionar livro! " + ex.Message);
            }
        }

        public async Task<Livro> UpdateLivro(int livroId, Livro model)
        {
            try
            {
                var livro = await _livroPersistence.GetLivroByIdAsync(livroId);
                if (livro == null) return null;

                model.Codl = livroId;

                _geralPersistence.Update(model);
                if (await _geralPersistence.SaveChangedAsync())
                {
                    return await _livroPersistence.GetLivroByIdAsync(model.Codl);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Editar Livro! "  + ex.Message);
            }
        }

        public async Task<bool> DeleteLivro(int livroId )
        {
            try
            {
                var livro = await _livroPersistence.GetLivroByIdAsync(livroId);
                if (livro == null) throw new Exception("N�o foi poss�vel excluir livro.");

                _geralPersistence.Delete<Livro>(livro);
                return await _geralPersistence.SaveChangedAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir Livro! " + ex.Message);
            }
        }

        public async Task<Livro[]> GetAllLivrosAsync()
        {
            try
            {
                var livros= await _livroPersistence.GetAllLivrosAsync();
                if (livros == null) return null;

                return livros;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Livro[]> GetAllLivrosByTituloAsync(string titulo)
        {
            try
            {
                var livros = await _livroPersistence.GetAllLivrosByTituloAsync(titulo);
                if (livros == null) return null;

                return livros;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Livro> GetLivroByIdAsync(int livroId)
        {
            try
            {
                var livros = await _livroPersistence.GetLivroByIdAsync(livroId);
                if (livros == null) return null;

                return livros;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}