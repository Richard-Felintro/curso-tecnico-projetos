using webapi.healthclinic.Domains;

namespace webapi.healthclinic.Interfaces
{
    /// <summary>
    /// Interface responsável pelos métodos do Paciente
    /// </summary>
    public interface IPacienteRepository
    {
        /// <summary>
        /// Busca um Paciente baseado no parametro IdUsuario do Usuario no qual ele está relacionado
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns>O Paciente achado</returns>
        public Paciente BuscarPorIdComUsuario(Guid IdUsuario);

        /// <summary>
        /// Cadastra o Paciente, utilizando o parametro IdUsuario para conectá-lo a um Usuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        public void Cadastrar(Guid IdUsuario);

        /// <summary>
        /// Cadastra o Paciente, utilizando o parametro id para conectá-lo a um Usuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        public void Deletar(Guid IdUsuario);
    }
}
