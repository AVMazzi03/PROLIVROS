using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProLivros.Application;
using ProLivros.Domain;
using ProLivros.Persistence;

namespace ProLivros.Application
{
    public class AssuntoService : IAssuntoService
    {
        private readonly IGeralPersistence _geralPersistence;
        private readonly IAssuntoPersistence _assuntoPersistence;

        public AssuntoService(IGeralPersistence geralPersistence, IAssuntoPersistence assuntoPersistence)
        {
            _geralPersistence = geralPersistence;
            _assuntoPersistence = assuntoPersistence;
        }
        public async Task<Assunto> AddAssunto(Assunto model)
        {
            try
            {
                _geralPersistence.Add<Assunto>(model);

                if (await _geralPersistence.SaveChangedAsync())
                {
                    return await _assuntoPersistence.GetAssuntoByIdAsync(model.CodAs);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Adicionar Autor! " + ex.Message);
            }
        }
        public async Task<Assunto> UpdateAssunto(int assuntoId, Assunto model)
        {
            try
            {
                var assunto = await _assuntoPersistence.GetAssuntoByIdAsync(assuntoId);
                if (assunto == null) return null;

                model.CodAs = assuntoId;

                _geralPersistence.Update(model);
                if (await _geralPersistence.SaveChangedAsync())
                {
                    return await _assuntoPersistence.GetAssuntoByIdAsync(model.CodAs);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao editar Autor! " + ex.Message);
            }
        }
        public async Task<bool> DeleteAssunto(int assuntoId)
        {
            try
            {
                var assunto = await _assuntoPersistence.GetAssuntoByIdAsync(assuntoId);
                if (assunto == null) throw new Exception("Não foi possível excluir assunto.");

                _geralPersistence.Delete<Assunto>(assunto);
                return await _geralPersistence.SaveChangedAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao excluir Assunto! " + ex.Message);
            }
        }

        public async Task<Assunto[]> GetAllAssuntosAsync()
        {
            try
            {
                var assuntos = await _assuntoPersistence.GetAllAssuntosAsync();
                if (assuntos == null) return null;

                return assuntos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Assunto[]> GetAllAssuntosByDescricaoAsync(string descricao)
        {
            try
            {
                var assuntos = await _assuntoPersistence.GetAllAssuntosByDescricaoAsync(descricao);
                if (assuntos == null) return null;

                return assuntos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Assunto> GetAssuntoByIdAsync(int assuntoId)
        {
            try
            {
                var assuntos = await _assuntoPersistence.GetAssuntoByIdAsync(assuntoId);
                if (assuntos == null) return null;

                return assuntos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}