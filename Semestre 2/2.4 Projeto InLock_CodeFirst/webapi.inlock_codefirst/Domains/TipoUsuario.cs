using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("TipoUsuario")]
    public class TipoUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(128)")]
        [Required(ErrorMessage = "Atributo obrigatório, nome de tipo de usuário não determinado.")]
        public string? Nome { get; set; }
    }
}
