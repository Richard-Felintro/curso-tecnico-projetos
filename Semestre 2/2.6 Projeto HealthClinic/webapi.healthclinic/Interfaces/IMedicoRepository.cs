using webapi.healthclinic.Domains;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos do Medico
    /// </summary>
    public interface IMedicoRepository
    {
        /// <summary>
        /// Busca um Medico baseado no parametro IdUsuario do Usuario no qual ele está relacionado
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns>O Medico achado</returns>
        public Medico BuscarPorIdComUsuario(Guid IdUsuario);
        /// <summary>
        /// Cadastra o Medico, utilizando o parametro IdUsuario para conectá-lo a um Usuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        public void Cadastrar(Guid IdUsuario);

        /// <summary>
        /// Cadastra o Medico, utilizando o parametro id para conectá-lo a um Usuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        public void Deletar(Guid IdUsuario);
    }
}
