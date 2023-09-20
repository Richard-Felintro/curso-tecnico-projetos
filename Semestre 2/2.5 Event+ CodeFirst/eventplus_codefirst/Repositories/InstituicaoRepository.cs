using eventplus_codefirst.Contexts;
using eventplus_codefirst.Domains;
using eventplus_codefirst.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eventplus_codefirst.Repositories
{
    public class InstituicaoRepository : IInsituicaoRepository
    {
        private readonly EventContext _eventContext;
        public InstituicaoRepository()
        {
            _eventContext = new EventContext();
        }
        public Instituicao BuscarIdEAtualizar(Guid id, Instituicao insti)
        {
            try
            {
                Instituicao editado = BuscarPorId(id);
                if (editado != null)
                {
                    editado.Endereco = insti.Endereco;
                    editado.NomeFantasia = insti.NomeFantasia;
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

        public Instituicao BuscarPorId(Guid id)
        {
            try
            {
                Instituicao insti = _eventContext.Instituicao.First(x => x.IdInstituicao == id);
                return insti;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Instituicao BuscarPorIdComEventos(Guid id)
        {
            try
            {
                Instituicao insti = _eventContext.Instituicao.Include(x => x.Eventos).First(x => x.IdInstituicao == id);
                return insti;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Instituicao insti)
        {
            _eventContext.Instituicao.Add(insti);
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

        public List<Instituicao> ListarTodos()
        {
            return _eventContext.Instituicao.ToList();
        }

        public List<Instituicao> ListarTodosComEventos()
        {
            return _eventContext.Instituicao.Include(x => x.Eventos).ToList();
        }
    }
}
