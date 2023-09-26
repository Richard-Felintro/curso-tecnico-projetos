using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.Domains
{
    /// <summary>
    /// Tabela que contem todos os prontuários cadastrados (parte da consulta)
    /// </summary>
    [Table(nameof(Prontuario))]
    public class Prontuario
    {
        /// <summary>
        /// Identificador único dos itens da tabela Prontuario
        /// </summary>
        [Key]
        public Guid IdProntuario { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Conteúdo textual do prontuário
        /// </summary>
        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Conteúdo do prontuário não determinado")]
        public string? Conteudo { get; set; }

        /// <summary>
        /// Foreign key referente a consulta que na qual o prontuário pertence
        /// </summary>
        [Required(ErrorMessage = "Consulta relacionada ao prontuário não determinada")]
        public Guid IdConsulta { get; set; }

        /// <summary>
        /// Consulta referenciado pela foreign key IdConsulta acima
        /// </summary>
        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }
    }
}
