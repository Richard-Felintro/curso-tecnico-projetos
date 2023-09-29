using webapi.healthclinic.Domains;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos da Clinica
    /// </summary>
    public interface IClinicaRepository
    {
        /// <summary> Busca uma Clinica, comparando seu IdClinica com o parametro id e o edita usando o parametro 'atualizar' para determinar seus novos parametros </summary>
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns> A Clinica atualizada </returns>
        public Clinica AtualizarPorId(Guid id, ClinicaViewModel atualizar);

        /// <summary>
        /// Busca uma Clinica, comparando seu IdClinica com o parametro id, se alguma Clinica for compatível ela é retornada
        /// </summary>
        /// <param name="id"></param>
        /// <returns> A Clinica buscada </returns>
        public Clinica BuscarPorId(Guid id);

        /// <summary>
        /// Cadastra a Clinica "cadastrado" e o adiciona ao banco de dados
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns> A Clinica cadastrada </returns>
        public Clinica Cadastrar(ClinicaViewModel cadastrado);

        /// <summary>
        /// Busca uma Clinica pelo seu Id e a deleta da database se for encontrada
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id);

        /// <summary>
        /// Transforma a tabela de Clinica em uma List de Clinica e a retorna
        /// </summary>
        /// <returns> Uma lista com todas as Clinica cadastradas </returns>
        public List<Clinica> ListarTodos();
    }
}