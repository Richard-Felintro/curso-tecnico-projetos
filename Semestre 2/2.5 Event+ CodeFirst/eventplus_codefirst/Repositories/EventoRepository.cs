using eventplus_codefirst.Contexts;
using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;

namespace eventplus_codefirst.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;
        public EventoRepository()
        {
            _eventContext = new();
        }

        public Evento BuscarIdEAtualizar(Guid id, Evento evento)
        {
            try
            {
                Evento editado = BuscarPorId(id);
                if (editado != null)
                {
                    editado.NomeEvento = evento.NomeEvento;
                    editado.DataEvento = evento.DataEvento;
                    editado.Descricao  =  evento.Descricao;
                    editado.IdTipoEvento = evento.IdTipoEvento;
                    editado.Instituicao = evento.Instituicao;
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

        public Evento BuscarPorId(Guid id)
        {
            try
            {
                Evento evento = _eventContext.Evento.First(x => x.IdEvento == id);
                return evento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Evento evento)
        {
            _eventContext.Evento.Add(evento);
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

        public List<Evento> ListarTodos()
        {
            return _eventContext.Evento.ToList();
        }
    }
}
