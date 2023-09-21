using eventplus_codefirst.Contexts;
using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;

namespace eventplus_codefirst.Repositories
{
    public class ComentarioEventoRepository : IComentarioEventoRepository
    {
        private readonly EventContext _eventContext;
        public ComentarioEventoRepository()
        {
            _eventContext = new();
        }

        public void AlterarExibicao(Guid id)
        {
            try
            {
                ComentarioEvento editado = BuscarPorId(id);
                if (editado.Exibe == true)
                {
                    editado.Exibe = false;
                    _eventContext.Update(editado);
                    _eventContext.SaveChanges();
                    return;
                }
                editado.Exibe = true;
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            try
            {
                ComentarioEvento ComentarioEvento = _eventContext.ComentarioEvento.First(x => x.IdComentarioEvento == id);
                return ComentarioEvento;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentarioEvento ComentarioEvento)
        {
            _eventContext.ComentarioEvento.Add(ComentarioEvento);
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

        public List<ComentarioEvento> ListarTodos()
        {
            return _eventContext.ComentarioEvento.ToList();
        }
    }
}
