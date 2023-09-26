using webapi.healthclinic.Domains;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos da Clinica
    /// </summary>
    public interface IClinicaRepository
    {
        /// <summary>
        /// Busca uma Clinica, comparando seu IdClinica com o parametro id e o edita usando o parametro 'atualizar' para determinar seus novos parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns>O usuário atualizado</returns>
        public Clinica AtualizarPorId(Guid id, Clinica atualizar);

        /// <summary>
        /// Busca uma Clinica, comparando seu IdClinica com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O Clinica buscado</returns>
        public Clinica BuscarPorId(Guid id);

        /// <summary>
        /// Cadastra a Clinica "cadastrado" e o adiciona ao banco de dados
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns>O Clinica cadastrado</returns>
        public Clinica Cadastrar(Clinica cadastrado);

        /// <summary>
        /// Busca uma Clinica, comparando seu IdClinica com o parametro id e a deleta da database
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id);

        /// <summary>
        /// Transforma a tabela de Clinica em uma List de Clinica e a retorna
        /// </summary>
        /// <returns>Uma lista com todos os Clinica cadastrados</returns>
        public List<Clinica> ListarTodos();
    }
}