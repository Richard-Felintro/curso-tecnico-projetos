using eventplus_codefirst.Contexts;
using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;

namespace eventplus_codefirst.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext _eventContext;
        public TipoUsuarioRepository()
        {
            _eventContext = new EventContext();
        }
        public TipoUsuario Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario editado = BuscarPorId(id);
                if (editado != null)
                {
                    editado.Titulo = tipoUsuario.Titulo;
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

        public TipoUsuario BuscarPorId(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuario = _eventContext.TipoUsuario.First(x => x.IdTipoUsuario == id);
                return tipoUsuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _eventContext.TipoUsuario.Add(tipoUsuario);
                _eventContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                _eventContext.TipoUsuario.Remove(BuscarPorId(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
            return _eventContext.TipoUsuario.ToList();
        }
    }
}
