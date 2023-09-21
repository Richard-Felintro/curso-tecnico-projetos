using eventplus_codefirst.Domains;

namespace eventplus_codefirst.Interfaces
{
    public interface IComentarioEventoRepository
    {
        public void Cadastrar(ComentarioEvento ComentarioEvento);
        public void Deletar(Guid id);
        public List<ComentarioEvento> ListarTodos();
        public ComentarioEvento BuscarPorId(Guid id);
        public void AlterarExibicao(Guid id);
    }
}
