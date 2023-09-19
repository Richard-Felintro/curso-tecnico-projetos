using System.ComponentModel.DataAnnotations;

namespace eventplus_codefirst.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email não determinado")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha não determinada")]
        public string? Senha { get; set; }
    }
}
