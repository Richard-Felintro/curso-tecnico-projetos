using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe representando da entidade Usuario.
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        public TipoUsuarioDomain? TiposUsuario { get; set; }
        [Required(ErrorMessage = "Email de usuário não determinado.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Senha de usuário não determinada.")]
        public string? Senha { get; set; }

    }
}
