using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.Domains
{
    /// <summary>
    /// Tabela que contem todos os usuário cadastrados
    /// </summary>
    [Table(nameof(Usuario))]
    public class Usuario
    {
        /// <summary>
        /// Identificador único dos itens da tabela Usuario
        /// </summary>
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        /// <summary>
        /// O nome referente ao Usuario
        /// </summary>
        [Column(TypeName = "VARCHAR(128)")]
        [Required(ErrorMessage = "Nome do usuário não determinado")]
        public string? Nome { get; set; }

        /// <summary>
        /// O email único referente ao Usuario
        /// </summary>
        [Column(TypeName = "VARCHAR(128)")]
        [Required(ErrorMessage = "Email do usuário não determinado")]
        public string? Email { get; set; }

        /// <summary>
        /// A senha referente ao Usuario que será futuramente criptografada
        /// </summary>
        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "Email do usuário não determinado")]
        [StringLength(60, MinimumLength = 6)]
        public string? Senha { get; set; }

        /// <summary>
        /// Referência a tabela TipoUsuario = FK
        /// </summary>
        [Required(ErrorMessage = "Tipo de usuário não determinado.")]
        public Guid IdTipoUsuario { get; set; }

        /// <summary>
        /// TipoUsuario referido pela FK acima
        /// </summary>
        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }

        /// <summary>
        /// Lista que contém todos os comentários feitos por este usuário
        /// </summary>
        public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
