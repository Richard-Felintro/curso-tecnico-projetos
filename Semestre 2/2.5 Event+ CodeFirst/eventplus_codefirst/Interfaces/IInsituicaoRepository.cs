using eventplus_codefirst.Domains;

namespace eventplus_codefirst.Interfaces
{
    public interface IInsituicaoRepository
    {
        public void Cadastrar(Instituicao insti);
        public void Deletar(Guid id);
        public List<Instituicao> ListarTodos();
        public List<Instituicao> ListarTodosComEventos();
        public Instituicao BuscarPorId(Guid id);
        public Instituicao BuscarPorIdComEventos(Guid id);
        public Instituicao BuscarIdEAtualizar(Guid id, Instituicao insti);
    }
}
