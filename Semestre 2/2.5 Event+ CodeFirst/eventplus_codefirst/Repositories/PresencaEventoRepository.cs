﻿using eventplus_codefirst.Contexts;
using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;

namespace eventplus_codefirst.Repositories
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext _eventContext;
        public PresencaEventoRepository()
        {
            _eventContext = new();
        }

        public PresencaEvento BuscarIdEAtualizar(Guid id, PresencaEvento PresencaEvento)
        {
            try
            {
                PresencaEvento editado = BuscarPorId(id);
                if (editado != null)
                {
                    editado.Situacao = PresencaEvento.Situacao;
                    _eventContext.Update(editado);
                    _eventContext.SaveChanges();
                    return editado;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            try
            {
                PresencaEvento PresencaEvento = _eventContext.PresencaEvento.First(x => x.IdPresencaEvento == id);
                return PresencaEvento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(PresencaEvento PresencaEvento)
        {
            _eventContext.PresencaEvento.Add(PresencaEvento);
            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            try
            {
                _eventContext.Remove(BuscarPorId(id));
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            return _eventContext.PresencaEvento.Where(x => x.Usuario.IdUsuario == id).ToList();
        }

        public List<PresencaEvento> ListarTodos()
        {
            return _eventContext.PresencaEvento.ToList();
        }
    }
}
