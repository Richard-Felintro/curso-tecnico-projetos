using webapi.healthclinic.Domains;
using webapi.healthclinic.ViewModels;

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
        public Usuario AtualizarPorId(Guid id, UsuarioViewModel atualizar);

        /// <summary>
        /// Busca um Usuario baseado em sua Senha e Email para saber se o login coincide
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
        /// Cadastra um novo usuário não Medico, utilizando um ViewModel e seu tipo
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public Usuario CadastrarUsuario(UsuarioViewModel cadastrado, string UserType);

        /// <summary>
        /// Cadastra um novo usuário do tipo Medico, utilizando um ViewModel e seu tipo
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public Usuario CadastrarMedico(MedicoViewModel cadastrado);

        /// <summary>
        /// Busca um Usuario, comparando seu IdUsuario com o parametro id e o deleta da database
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id);

        /// <summary>
        /// Transforma a tabela de todos os Usuario tipo Medico
        /// </summary>
        /// <returns>Uma lista com todos os Usuario tipo Medico cadastrados</returns>
        //public List<Usuario> ListarMedicos();
    }
}
