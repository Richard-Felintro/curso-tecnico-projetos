using webapi.healthclinic.Domains;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos do Prontuario
    /// </summary>
    public interface IProntuarioRepository
    {
        /// <summary>
        /// Busca um Prontuario, comparando seu IdProntuario com o parametro id e o edita usando o parametro 'atualizar' para determinar seus novos parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns>O usuário atualizado</returns>
        public Prontuario AtualizarPorId(Guid id, ProntuarioViewModel atualizar);

        /// <summary>
        /// Busca um Prontuario, comparando seu IdProntuario com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O Prontuario buscado</returns>
        public Prontuario BuscarPorId(Guid id);

        /// <summary>
        /// Cadastra o Prontuario "cadastrado" e o adiciona ao banco de dados
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns>O Prontuario cadastrado</returns>
        public Prontuario Cadastrar(ProntuarioViewModel cadastrado);

        /// <summary>
        /// Busca um Prontuario, comparando seu IdProntuario com o parametro id e o deleta da database
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id);

        /// <summary>
        /// Transforma a tabela de Prontuario em uma List de Prontuario e a retorna
        /// </summary>
        /// <returns>Uma lista com todos os Prontuario cadastrados</returns>
        public List<Prontuario> ListarTodos();
    }
}
