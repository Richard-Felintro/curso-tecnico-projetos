using webapi.healthclinic.Domains;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos do Usuario
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Busca um Usuario, comparando seu IdUsuario com o parametro id e o edita usando o parametro 'atualizar' para determinar seus novos parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns>O usuário atualizado</returns>
        public Usuario AtualizarPorId(Guid id, Usuario atualizar);

        /// <summary>
        /// Busca um Usuario baseado em sua Senha & Email para saber se o login coincide
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>O Usuario que coincide com o email e senha, nulo se nenhum for achado</returns>
        public Usuario BuscarPorEmailESenha(string email, string senha);

        /// <summary>
        /// Busca um Usuario, comparando seu IdUsuario com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O Usuario buscado</returns>
        public Usuario BuscarPorId(Guid id);

        /// <summary>
        /// Cadastra o Usuario "cadastrado" e o adiciona ao banco de dados
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns>O Usuario cadastrado</returns>
        public Usuario Cadastrar(Usuario cadastrado);

        /// <summary>
        /// Busca um Usuario, comparando seu IdUsuario com o parametro id e o deleta da database
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id);

        /// <summary>
        /// Transforma a tabela de Usuario em uma List de Usuario e a retorna
        /// </summary>
        /// <returns>Uma lista com todos os Usuario cadastrados</returns>
        public List<Usuario> ListarTodos();
    }
}
