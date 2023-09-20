using eventplus_codefirst.Domains;

namespace eventplus_codefirst.Interfaces
{
    public interface ITipoEventoRepository
    {
        public void Cadastrar(TipoEvento insti);
        public void Deletar(Guid id);
        public List<TipoEvento> ListarTodos();
        public List<TipoEvento> ListarTodosComEventos();
        public TipoEvento BuscarPorId(Guid id);
        public TipoEvento BuscarPorIdComEventos(Guid id);
        public TipoEvento BuscarIdEAtualizar(Guid id, TipoEvento insti);
    }
}
