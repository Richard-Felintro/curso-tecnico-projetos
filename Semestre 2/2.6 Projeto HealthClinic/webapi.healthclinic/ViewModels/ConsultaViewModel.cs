using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace webapi.healthclinic.ViewModels
{
    /// <summary>
    /// ViewModel contendo todos os dados relevantes para cadastrar uma nova Consulta
    /// </summary>
    public class ConsultaViewModel
    {
        /// <summary>
        /// A data de atendimento dessa consulta em questão
        /// </summary>
        [DefaultValue("DD/MM/YYYY")]
        public string? DataAtendimento { get; set; }

        /// <summary>
        /// Horário de atendimento da Consulta
        /// </summary>
        [DefaultValue("HH:MM:SS")]
        public string? HoraAtendimento { get; set; }

        /// <summary>
        /// Id do Paciente que será consultado
        /// </summary>
        public Guid IdPaciente { get; set; }

        /// <summary>
        /// Id do Medico que será consultado
        /// </summary>
        public Guid IdMedico { get; set; }
    }
}
