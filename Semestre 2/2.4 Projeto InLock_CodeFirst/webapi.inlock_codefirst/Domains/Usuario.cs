using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace webapi.inlock_codefirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email),IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(128)")]
        [Required(ErrorMessage = "Atributo obrigatório, Email de usuário não determinado")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "Atributo obrigatório, Senha de usuário não determinado")]
        [StringLength (60, MinimumLength = 6, ErrorMessage = "Senha deve conter entre 8 e 60 caracteres")]
        public string? Senha { get; set; }

        // Foreign Key -  Referência a tabela de tipos de usuário
        [Required(ErrorMessage = "Atributo obrigatório, ID de tipo de usuário não determinado")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
