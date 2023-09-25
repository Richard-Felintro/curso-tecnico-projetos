using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.Domains
{
    /// <summary>
    /// Tabela que contem as informações de administrador a todos os usuários que as contém
    /// </summary>
    [Table(nameof(Administrador))]
    public class Administrador
    {
        /// <summary>
        /// Identificador único dos itens da tabela Administrador
        /// </summary>
        [Key]
        public Guid IdAdministrador { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Foreign key referente ao usuário relacionado aos dados de Administrador
        /// </summary>
        [Required(ErrorMessage = "Usuário relacionado aos dados de administrador não determinados")]
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Usuario referenciado pela foreign key IdUsuario acima
        /// </summary>
        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
    }
}
