using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe responsável pela entidade TipoUsuario
    /// </summary>
    public class TipoUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Título do tipo de usuário não determinado.")]
        public string? Titulo { get; set; }
    }
}