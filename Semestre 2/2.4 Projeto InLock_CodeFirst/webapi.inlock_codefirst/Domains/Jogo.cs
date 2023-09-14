using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("Jogo")]
    public class Jogo
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(128)")]
        [Required(ErrorMessage = "Atributo obrigatório, Nome de jogo não determinado")]
        public string? NomeJogo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Atributo obrigatório, Descrição de jogo não determinado")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Atributo obrigatório, Data de lançamento de jogo não determinado")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "DECIMAL(6,2)")]
        [Required(ErrorMessage = "Atributo obrigatório, preço de jogo não determinado")]
        public decimal Preco { get; set; }

        // Foreign Key -  Referência a tabela de estúdio
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }
    }
}
