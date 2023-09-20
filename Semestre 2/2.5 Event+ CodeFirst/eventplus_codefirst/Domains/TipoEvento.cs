using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventplus_codefirst.Domains
{
    [Table(nameof(TipoEvento))]
    public class TipoEvento
    {
        [Key]
        public Guid IdTipoEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(64)")]
        [Required(ErrorMessage = "Título do tipo de evento não determinado.")]
        public string? Titulo { get; set; }
        // Lista de eventos com este tipo
        public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
