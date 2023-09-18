using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventplus_codefirst.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(64)")]
        [Required(ErrorMessage = "Nome de usuário não determinado.")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage = "Email não determinado.")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = " Senha não determinada.")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter entre 6 e 60 caracteres")]
        public string? Senha { get; set; }

        // Referência a tabela TipoUsuario = FK
        [Required(ErrorMessage = "Tipo de usuário não determinado.")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
