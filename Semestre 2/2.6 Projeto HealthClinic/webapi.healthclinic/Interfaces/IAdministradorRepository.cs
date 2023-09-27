using webapi.healthclinic.Domains;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos do Administrador
    /// </summary>
    public interface IAdministradorRepository
    {
        /// <summary>
        /// Busca um Administrador baseado no parametro IdUsuario do Usuario no qual ele está relacionado
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns>O Administrador achado</returns>
        public Administrador BuscarPorId(Guid IdUsuario);

        /// <summary>
        /// Cadastra o Administrador, utilizando o parametro IdUsuario para conectá-lo a um Usuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        public void Cadastrar(Guid IdUsuario);

        /// <summary>
        /// Cadastra o Administrador, utilizando o parametro id para conectá-lo a um Usuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        public void Deletar(Guid IdUsuario);
    }
}
