using Microsoft.EntityFrameworkCore;
using webapi.healthclinic.Domains;

namespace webapi.healthclinic.Contexts
{
    /// <summary>
    /// Contexto que conecta esta API com o banco
    /// </summary>
    public class _context : DbContext
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
        /// Determina os dados a serem utilizados no processo de configuração do banco de dado e Migration
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE01-S15; Database = HealthClinic_Tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true;");
        }
    }
}
