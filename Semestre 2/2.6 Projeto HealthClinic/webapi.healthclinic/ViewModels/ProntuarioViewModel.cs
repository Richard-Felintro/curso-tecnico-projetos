using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace webapi.healthclinic.ViewModels
{
    /// <summary>
    /// ViewModel contendo todos os dados relevantes para cadastrar um novo Prontuario
    /// </summary>
    public class ProntuarioViewModel
    {
        /// <summary>
        /// O conteúdo do Prontuario em questão
        /// </summary>
        public string? Conteudo { get; set; }

        /// <summary>
        /// IdConsulta do Prontuario
        /// </summary>
        public Guid IdConsulta { get; set; }
    }
}