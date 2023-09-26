using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinic.ViewModels
{
    /// <summary>
    /// O ViewModel que o usuário terá acesso quando estiver se logando a uma conta
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// O email a ser informado na ViewModel para se logar
        /// </summary>
        [Required(ErrorMessage = "Email da ViewModel não determinado")]
        public string? Email { get; set; }

        /// <summary>
        /// O senha a ser informado na ViewModel para se logar
        /// </summary>
        [Required(ErrorMessage = "Senha da ViewModel não determinado")]
        public string? Senha { get; set; }
    }
}
