using eventplus_codefirst.Domains;

namespace eventplus_codefirst.Interfaces
{
    public interface IEventoRepository
    {
        public void Cadastrar(Evento evento);
        public void Deletar(Guid id);
        public List<Evento> ListarTodos();
        public Evento BuscarPorId(Guid id);
        public Evento BuscarIdEAtualizar(Guid id, Evento evento);
    }
}
