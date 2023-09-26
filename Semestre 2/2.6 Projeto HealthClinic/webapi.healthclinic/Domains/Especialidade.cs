using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webapi.healthclinic.Domains
{
    /// <summary>
    /// Tabela que contem todas as especialidades de médico cadastradas
    /// </summary>
    [Table(nameof(Especialidade))]
    public class Especialidade
    {
        /// <summary>
        /// Identificador único dos itens da tabela Especialidade
        /// </summary>
        [Key]
        public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Título (nome) da Especialidade
        /// </summary>
        [Column(TypeName = "VARCHAR(64)")]
        [Required(ErrorMessage = "Título do tipo de usuário não determinado.")]
        public string? Titulo { get; set; }
    }
}
