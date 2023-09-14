using webapi.inlock_codefirst.Domains;

namespace webapi.inlock_codefirst.Interfaces
{
    public interface IUsuarioRepository
    {
        // Busca um usuário utilizando seu email e senha
        public Usuario BuscarUsuario(string email, string senha);

        // Cadastra um novo usuário
        public void CadastrarUsuario(Usuario usuario);
    }
}
