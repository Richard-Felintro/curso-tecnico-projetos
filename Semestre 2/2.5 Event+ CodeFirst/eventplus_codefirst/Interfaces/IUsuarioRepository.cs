using eventplus_codefirst.Contexts;
using eventplus_codefirst.Domains;
using eventplus_codefirst.Utils;

namespace eventplus_codefirst.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario BuscarPorEmailESenha(string email, string senha);
        public Usuario BuscarPorId(Guid id);
        public void Cadastrar(Usuario usuario);
        public void Deletar(Guid id);
        public Usuario BuscarIdEAtualizar(Guid id, Usuario usuario);
        public List<Usuario> ListarTodos();
    }
}
