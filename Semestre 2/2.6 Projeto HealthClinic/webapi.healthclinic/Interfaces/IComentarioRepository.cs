using webapi.healthclinic.Domains;
using webapi.healthclinic.ViewModels;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos do Comentario
    /// </summary>
    public interface IComentarioRepository
    {
        /// <summary>
        /// Busca um Comentario, comparando seu IdComentario com o parametro id e o edita usando o parametro 'atualizar' para determinar seus novos parametros
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atualizar"></param>
        /// <returns>O usuário atualizado</returns>
        public Comentario AtualizarPorId(Guid id, ComentarioViewModel atualizar);

        /// <summary>
        /// Busca um Comentario, comparando seu IdComentario com o parametro id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O Comentario buscado</returns>
        public Comentario BuscarPorId(Guid id);

        /// <summary>
        /// Cadastra o Comentario "cadastrado" e o adiciona ao banco de dados
        /// </summary>
        /// <param name="cadastrado"></param>
        /// <returns>O Comentario cadastrado</returns>
        public Comentario Cadastrar(ComentarioViewModel cadastrado);

        /// <summary>
        /// Busca um Comentario, comparando seu IdComentario com o parametro id e o deleta da database
        /// </summary>
        /// <param name="id"></param>
        public void DeletarPorID(Guid id);

        /// <summary>
        /// Transforma a tabela de Comentario em uma List de Comentario e a retorna
        /// </summary>
        /// <returns>Uma lista com todos os Comentario cadastrados</returns>
        public List<Comentario> ListarTodos();
    }
}