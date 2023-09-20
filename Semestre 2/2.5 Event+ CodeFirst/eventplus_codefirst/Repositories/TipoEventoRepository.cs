using eventplus_codefirst.Contexts;
using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eventplus_codefirst.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _eventoContext;
        public TipoEventoRepository()
        {
            _eventoContext = new();
        }
        public TipoEvento BuscarIdEAtualizar(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                TipoEvento buscado = BuscarPorId(id);
                if (buscado != null)
                {
                    buscado.Titulo = tipoEvento.Titulo;
                    _eventoContext.Update(buscado);
                    _eventoContext.SaveChanges();
                    return buscado;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoEvento BuscarPorId(Guid id)
        {
            return _eventoContext.TipoEvento.First(x => x.IdTipoEvento == id);
        }

        public TipoEvento BuscarPorIdComEventos(Guid id)
        {
            return _eventoContext.TipoEvento.Include(x => x.Eventos).First(x => x.IdTipoEvento == id);
        }

        public void Cadastrar(TipoEvento insti)
        {
            _eventoContext.Add(insti);
            _eventoContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            _eventoContext.Remove(BuscarPorId(id));
        }

        public List<TipoEvento> ListarTodos()
        {
            return _eventoContext.TipoEvento.ToList();
        }

        public List<TipoEvento> ListarTodosComEventos()
        {
            return _eventoContext.TipoEvento.Include(x => x.Eventos).ToList();
        }
    }
}
