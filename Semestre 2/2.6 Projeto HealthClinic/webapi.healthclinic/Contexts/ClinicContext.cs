using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.ComponentModel;
using webapi.healthclinic.Domains;
using webapi.healthclinic.Utils;

namespace webapi.healthclinic.Contexts
{
    /// <summary>
    /// Contexto que conecta esta API com o banco
    /// </summary>
    public class ClinicContext : DbContext
    {
        /// <summary>
        /// O DbSet referente a tabela de Clinica
        /// </summary>
        public DbSet<Clinica> Clinica { get; set; }

        /// <summary>
        /// O DbSet referente a tabela de Consulta
        /// </summary>
        public DbSet<Consulta> Consulta { get; set; }

        /// <summary>
        /// O DbSet referente a tabela de Especialidade
        /// </summary>
        public DbSet<Especialidade> Especialidade { get; set; }
        /// <summary>
        /// O DbSet referente a tabela de Medico
        /// </summary>
        public DbSet<Medico> Medico { get; set; }
        /// <summary>
        /// O DbSet referente a tabela de Paciente
        /// </summary>
        public DbSet<Paciente> Paciente { get; set; }
        /// <summary>
        /// O DbSet referente a tabela de Prontuario
        /// </summary>
        public DbSet<Prontuario> Prontuario { get; set; }
        /// <summary>
        /// O DbSet referente a tabela de TipoUsuario
        /// </summary>
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        /// <summary>
        /// O DbSet referente a tabela de Usuario
        /// </summary>
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// O DbSet referente a tabela de Comentario
        /// </summary>
        public DbSet<Comentario> Comentario { get; set; }

        /// <summary>
        /// Determina a string de conexão quando o banco é configurado
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE01-S15; Database = HealthClinic_Tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true;", x => x.UseDateOnlyTimeOnly());
        }
    }
}
