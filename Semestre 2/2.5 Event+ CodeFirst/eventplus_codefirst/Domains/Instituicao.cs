using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace eventplus_codefirst.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ de instituição não determinado.")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage = "Endereço de instituição não determinado.")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage = "Nome fantasia de instituição não determinado.")]
        public string? NomeFantasia { get; set; }

        // Lista de eventos Associados a esta instituição
        public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
