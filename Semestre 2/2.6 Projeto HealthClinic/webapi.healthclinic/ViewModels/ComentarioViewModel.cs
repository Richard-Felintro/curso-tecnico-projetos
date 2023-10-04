namespace webapi.healthclinic.ViewModels
{
    /// <summary>
    /// ViewModel contendo todos os dados relevantes para cadastrar um novo Prontuario
    /// </summary>
    public class ComentarioViewModel
    {
        /// <summary>
        /// O conteúdo do Comentario em questão
        /// </summary>
        public string? Conteudo { get; set; }

        /// <summary>
        /// IdConsulta do Prontuario
        /// </summary>
        public Guid IdConsulta { get; set; }

        /// <summary>
        /// IdPaciente do Prontuario
        /// </summary>
        public Guid IdPaciente { get; set; }
    }
}
