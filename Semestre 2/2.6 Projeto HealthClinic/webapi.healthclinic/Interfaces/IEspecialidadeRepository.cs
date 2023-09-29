using webapi.healthclinic.Domains;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos da Especialidade
    /// </summary>
    public interface IEspecialidadeRepository
    {
        /// <summary>
        /// Busca uma Especialidade, comparando seu IdEspecialidade com o parametro id e o edita usando o parametro 'atualizar' para determinar seus novos parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns>O usuário atualizado</returns>
        public Especialidade AtualizarPorId(Guid id, EspecialidadeViewModel atualizar);

        /// <summary>
        /// Busca uma Especialidade, comparando seu IdEspecialidade com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O Especialidade buscado</returns>
        public Especialidade BuscarPorId(Guid id);

        /// <summary>
        /// Cadastra a Especialidade "cadastrado" e o adiciona ao banco de dados
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns>O Especialidade cadastrado</returns>
        public Especialidade Cadastrar(EspecialidadeViewModel cadastrado);

        /// <summary>
        /// Busca uma Especialidade, comparando seu IdEspecialidade com o parametro id e a deleta da database
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id);

        /// <summary>
        /// Transforma a tabela de Especialidade em uma List de Especialidade e a retorna
        /// </summary>
        /// <returns>Uma lista com todos os Especialidade cadastrados</returns>
        public List<Especialidade> ListarTodos();
    }
}
