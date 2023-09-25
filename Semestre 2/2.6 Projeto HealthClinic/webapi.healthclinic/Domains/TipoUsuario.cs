using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.Domains
{
    /// <summary>
    /// Tabela que contem todos os tipos de usuário cadastrados
    /// </summary>
    [Table(nameof(TipoUsuario))]
    public class TipoUsuario
    {
        /// <summary>
        /// Identificador único dos itens da tabela TipoUsuario
        /// </summary>
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Título (nome) do TipoUsuario
        /// </summary>
        [Column(TypeName = "VARCHAR(32)")]
        [Required(ErrorMessage = "Título do tipo de usuário não determinado.")]
        public string? Titulo { get; set; }
    }
}
