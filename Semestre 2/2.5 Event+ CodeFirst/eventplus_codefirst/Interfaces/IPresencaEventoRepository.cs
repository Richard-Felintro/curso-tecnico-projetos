using eventplus_codefirst.Domains;

namespace eventplus_codefirst.Interfaces
{
    public interface IPresencaEventoRepository
    {
        public void Cadastrar(PresencaEvento Presenca);
        public void Deletar(Guid id);
        public List<PresencaEvento> ListarTodos();
        public PresencaEvento BuscarPorId(Guid id);
        public PresencaEvento BuscarIdEAtualizar(Guid id, PresencaEvento Presenca);
    }
}
