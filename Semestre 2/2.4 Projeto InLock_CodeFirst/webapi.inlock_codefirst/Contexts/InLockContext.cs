using Microsoft.EntityFrameworkCore;
using webapi.inlock_codefirst.Domains;

namespace webapi.inlock_codefirst.Contexts
{
    public class InLockContext : DbContext
    {
        /// <summary>
        /// Definição das entidades do banco de dados
        /// </summary>
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Estudio> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE01-S15; Database = InLockTarde_CodeFirst; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
