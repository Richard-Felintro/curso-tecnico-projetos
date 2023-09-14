using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("Estudio")]
    public class Estudio
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(128)")]
        [Required(ErrorMessage = "Atributo obrigatório, Nome de estúdio não determinado")] 
        public string? NomeEstudio { get; set; }

        // Referência a lista de jogos.
        public List<Jogo>? Jogos { get; set; }
    }
}
