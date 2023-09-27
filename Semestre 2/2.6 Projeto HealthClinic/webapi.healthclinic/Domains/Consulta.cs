using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace webapi.healthclinic.Domains
{
    /// <summary>
    /// Tabela que contem todas as consultas cadastradas
    /// </summary>
    [Table(nameof(Consulta))]   
    public class Consulta
    {
        /// <summary>
        /// Identificador único dos itens da tabela Consulta
        /// </summary>
        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        /// <summary>
        /// A data de acontecimento da consulta
        /// </summary>
        [Column(TypeName ="DATE")]
        [Required(ErrorMessage = "Data de atendimento não determinada")]
        public DateTime DataAtendimento { get; set; }

        /// <summary>
        /// O horário esperado do início da consulta
        /// </summary>
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Hora de atendimento não determinada")]
        public TimeOnly HoraAtendimento { get; set; } = new();

        /// <summary>
        /// Foreign key referente ao usuário que comparecerá a consulta
        /// </summary>
        [Required(ErrorMessage = "Paciente relacionado a consulta não determinado")]
        public Guid IdPaciente { get; set; }

        /// <summary>
        /// Paciente referenciado pela foreign key IdPaciente acima
        /// </summary>
        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }

        /// <summary>
        /// Foreign key referente ao usuário que comparecerá a consulta
        /// </summary>
        [Required(ErrorMessage = "Medico relacionado a consulta não determinado")]
        public Guid IdMedico { get; set; }

        /// <summary>
        /// Medico referenciado pela foreign key IdMedico acima
        /// </summary>
        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }
    }
}
