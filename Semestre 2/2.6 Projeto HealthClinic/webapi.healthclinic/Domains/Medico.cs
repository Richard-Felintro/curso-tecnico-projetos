using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.Domains
{
    /// <summary>
    /// Tabela que contem as informações de médico a todos os usuários que as contém
    /// </summary>
    [Table(nameof(Medico))]
    public class Medico
    {
        /// <summary>
        /// Identificador único dos itens da tabela Medico
        /// </summary>
        [Key]
        public Guid IdMedico { get; set; } = Guid.NewGuid();

        /// <summary>
        /// O identificador único CRM de um profissional médico cadastrado
        /// </summary>
        [Column(TypeName = "CHAR(8)")]
        [Required(ErrorMessage = "CRM do médico não determinado")]
        [StringLength(8, MinimumLength = 8)]
        public string? CRM { get; set; }

        /// <summary>
        /// Foreign key referente ao usuário relacionado aos dados de Medico
        /// </summary>
        [Required(ErrorMessage = "Usuário relacionado aos dados de médico não determinados")]
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Usuario referenciado pela foreign key IdUsuario acima
        /// </summary>
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
