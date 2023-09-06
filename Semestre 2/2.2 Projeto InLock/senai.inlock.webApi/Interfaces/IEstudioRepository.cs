using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de estúdios.
    /// </summary>
    public interface IEstudioRepository
    {
        /// <summary>
        /// Exibe todos os estúdios cadastrados.
        /// </summary>
        /// <returns>Lista incluindo todos os estúdios cadastrados.</returns>
        List<EstudioDomain> ListarTodos();

        /// <summary>
        /// Exibe um estúdio cadastrado; utiliza o IdEstudio para selecioná-lo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O EstudioDomain do estúdio correspondente ao id.</returns>
        EstudioDomain ListarPorId(int id);
    }
}
