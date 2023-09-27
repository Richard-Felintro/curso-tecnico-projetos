using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.Domains
{
    /// <summary>
    /// Tabela que contem todas as clínicas cadastradas
    /// </summary>
    [Table(nameof(Clinica))]
    public class Clinica
    {
        /// <summary>
        /// Identificador único dos itens da tabela Clinica
        /// </summary>
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Razão social (nome formal) da Clinica
        /// </summary>
        [Column(TypeName = "VARCHAR(128)")]
        [Required(ErrorMessage = "Razão social da clínica não determinado")]
        public string? RazaoSocial { get; set; }

        /// <summary>
        /// Nome fantasia (nome informal) da Clinica
        /// </summary>
        [Column(TypeName = "VARCHAR(128)")]
        [Required(ErrorMessage = "Nome fantasia da clínica não determinado")]
        public string? NomeFantasia { get; set; }

        /// <summary>
        /// Endereço da Clinica
        /// </summary>
        [Column(TypeName = "VARCHAR(256)")]
        [Required(ErrorMessage = "Endereço da clínica não determinado")]
        public string? Endereco { get; set; }

        /// <summary>
        /// Horário no qual a Clinica em questao abre diariamente
        /// </summary>
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horário de início de atendimento não determinada")]
        public TimeOnly AtendimentoInicio { get; set; }

        /// <summary>
        /// Horário no qual a Clinica em questao fecha diariamente
        /// </summary>
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horário do fim de atendimento não determinada")]
        public TimeOnly AtendimentoFim { get; set; }
    }
}
