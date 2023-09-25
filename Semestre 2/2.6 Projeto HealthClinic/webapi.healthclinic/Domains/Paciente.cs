using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.Domains
{
    /// <summary>
    /// Tabela que contem as informações de paciente a todos os usuários que as contém
    /// </summary>
    [Table(nameof(Paciente))]
    public class Paciente
    {
        /// <summary>
        /// Identificador único dos itens da tabela Paciente
        /// </summary>
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Foreign key referente ao usuário relacionado aos dados de Paciente
        /// </summary>
        [Required(ErrorMessage = "Usuário relacionado aos dados de paciente não determinados")]
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Usuario referenciado pela foreign key IdUsuario acima
        /// </summary>
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
