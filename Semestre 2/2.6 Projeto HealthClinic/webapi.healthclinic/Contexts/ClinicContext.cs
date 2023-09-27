using Microsoft.EntityFrameworkCore;
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
        /// O DbSet referente a tabela de Administrador
        /// </summary>
        public DbSet<Administrador> Administrador { get; set; }
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
        /// Determina que o TimeOnly será convertido para ser usado propriamente no campo
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateOnly>()
            .HaveConversion<Utils.DateOnlyConverter, DateOnlyComparer>()
            .HaveColumnType("date");

            builder.Properties<TimeOnly>()
            .HaveConversion<Utils.TimeOnlyConverter, TimeOnlyComparer>()
            .HaveColumnType("time");
        }

        /// <summary>
        /// Determina os dados a serem utilizados no processo de configuração do banco de dado e Migration
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE01-S15; Database = HealthClinic_Tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true;");
        }
    }
}
