using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventplus_codefirst.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data do evento não determinada.")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(128)")]
        [Required(ErrorMessage = "Título de evento não determinada.")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Título de evento não determinada.")]
        public string? Descricao { get; set; }

        // Referência da tabela TipoEvento = FK
        [Required(ErrorMessage = "Tipo de evento não determinado.")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TipoEvento? TipoEvento { get; set; }

        // Referência da tabela Instituicao = FK
        [Required(ErrorMessage = "Instituição do evento não determinada.")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }
    }
}
