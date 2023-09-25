using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.Domains
{
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
        public DateOnly DataAtendimento { get; set; }

        /// <summary>
        /// O horário esperado do início da consulta
        /// </summary>
        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Hora de atendimento não determinada")]
        public TimeOnly HoraAtendimento { get; set; }

        /// <summary>
        /// O conteúdo do prontuário de uma consulta, este campo é nulável para que possa ser preenchido após a consulta
        /// </summary>
        [Column(TypeName = "TEXT")]
        public string? Prontuario { get; set; }

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
