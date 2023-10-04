using webapi.healthclinic.Domains;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos da Consulta
    /// </summary>
    public interface IConsultaRepository
    {
        /// <summary>
        /// Busca uma Consulta, comparando seu IdConsulta com o parametro id e o edita usando o parametro 'atualizar' para determinar seus novos parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns>O usuário atualizado</returns>
        public Consulta AtualizarPorId(Guid id, ConsultaViewModel atualizar);

        /// <summary>
        /// Busca uma Consulta, comparando seu IdConsulta com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O Consulta buscado</returns>
        public Consulta BuscarPorId(Guid id);

        /// <summary>
        /// Cadastra a Consulta "cadastrado" e o adiciona ao banco de dados
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns>O Consulta cadastrado</returns>
        public Consulta Cadastrar(ConsultaViewModel cadastrado);

        /// <summary>
        /// Busca uma Consulta, comparando seu IdConsulta com o parametro id e a deleta da database
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id);

        /// <summary>
        /// Transforma a tabela de Consulta em uma List de Consulta e a retorna
        /// </summary>
        /// <returns>Uma lista com todos os Consulta cadastrados</returns>
        public List<Consulta> ListarTodos();
    }
}
