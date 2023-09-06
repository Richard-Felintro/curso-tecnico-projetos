using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de jogos.
    /// </summary>
    public interface IJogoRepository
    {
        /// <summary>
        /// Cadastra um novo jogo; Para administradores apenas.
        /// </summary>
        /// <param name="novoJogo"></param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Exibe todos os jogos cadastrados e seus estúdios.
        /// </summary>
        /// <returns>Lista incluindo todos os jogos cadastrados.</returns>
        List<JogoDomain> ListarTodos();

        /// <summary>
        /// Exibe um jogo cadastrado e seu estúdio; utiliza o IdJogo para selecioná-lo.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O JogoDomain do jogo correspondente.</returns>
        JogoDomain ListarPorId(int id);
    }
}
