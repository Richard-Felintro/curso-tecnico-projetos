using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinic.ViewModels
{
    /// <summary>
    /// ViewModel contendo os dados relevantes para o cadastro de um médico não médico
    /// </summary>
    public class MedicoViewModel
    {
        /// <summary>
        /// Nome do médico sendo cadastrado
        /// </summary>
        [Required]
        public string? Nome { get; set; }

        /// <summary>
        /// Email do médico sendo cadastrado
        /// </summary>
        [Required]
        public string? Email { get; set; }

        /// <summary>
        /// Senha do médico sendo cadastrado
        /// </summary>
        [Required]
        public string? Senha { get; set; }

        /// <summary>
        /// CRM do médico sendo cadastrado
        /// </summary>
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string? CRM { get; set; }

        /// <summary>
        /// IdEspecialidade do médico sendo cadastrado
        /// </summary>
        public Guid IdEspecialidade { get; set; }

        /// <summary>
        /// IdClinica do médico sendo cadastrado
        /// </summary>
        public Guid IdClinica { get; set; }
    }
}
