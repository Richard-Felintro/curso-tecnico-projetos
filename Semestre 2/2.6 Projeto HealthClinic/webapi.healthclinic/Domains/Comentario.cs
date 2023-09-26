using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.Domains
{
    /// <summary>
    /// Tabela que contem todos os comentários cadastrados
    /// </summary>
    [Table(nameof(Comentario))]
    public class Comentario
    {
        /// <summary>
        /// Identificador único dos itens da tabela Usuario
        /// </summary>
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Foreign key referente a consulta que na qual o comentário pertence
        /// </summary>
        [Required(ErrorMessage = "Consulta relacionada ao comentário não determinada")]
        public Guid IdConsulta { get; set; }

        /// <summary>
        /// Consulta referenciado pela foreign key IdConsulta acima
        /// </summary>
        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }

        /// <summary>
        /// Foreign key referente ao usuario que na qual o comentário pertence
        /// </summary>
        [Required(ErrorMessage = "Usuario relacionada ao comentário não determinada")]
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Usuario referenciado pela foreign key IdUsuario acima
        /// </summary>
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
