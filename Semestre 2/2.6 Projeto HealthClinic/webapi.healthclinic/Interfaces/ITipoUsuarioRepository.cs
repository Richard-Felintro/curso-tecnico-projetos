using webapi.healthclinic.Domains;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos do TipoUsuario
    /// </summary>
    public interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Busca um TipoUsuario, comparando seu IdTipoUsuario com o parametro id e o edita usando o parametro 'atualizar' para determinar seus novos parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns>O usuário atualizado</returns>
        public TipoUsuario AtualizarPorId(Guid id, TipoUsuario atualizar);

        /// <summary>
        /// Busca um TipoUsuario, comparando seu IdTipoUsuario com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O TipoUsuario buscado</returns>
        public TipoUsuario BuscarPorId(Guid id);

        /// <summary>
        /// Cadastra o TipoUsuario "cadastrado" e o adiciona ao banco de dados
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns>O TipoUsuario cadastrado</returns>
        public TipoUsuario Cadastrar(TipoUsuario cadastrado);

        /// <summary>
        /// Busca um TipoUsuario, comparando seu IdTipoUsuario com o parametro id e o deleta da database
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id);

        /// <summary>
        /// Transforma a tabela de TipoUsuario em uma List de TipoUsuario e a retorna
        /// </summary>
        /// <returns>Uma lista com todos os TipoUsuario cadastrados</returns>
        public List<TipoUsuario> ListarTodos();
    }
}
