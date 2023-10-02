using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinic.ViewModels
{
    /// <summary>
    /// ViewModel contendo os dados relevantes para o cadastro de um usuário não médico
    /// </summary>
    public class UsuarioViewModel
    {
        /// <summary>
        /// Nome do usuário sendo cadastrado
        /// </summary>
        [Required]
        public string? Nome { get; set; }
        /// <summary>
        /// Email do usuário sendo cadastrado
        /// </summary>
        [Required]
        public string? Email { get; set; }
        /// <summary>
        /// Senha do usuário sendo cadastrado
        /// </summary>
        [Required]
        public string? Senha { get; set; }
        /// <summary>
        /// CRM do Medi
        /// </summary>
        /// [Required]

        //[StringLength(8, MinimumLength = 8)]
        //public string CRM { get; set; }
    }
}
