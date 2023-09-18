using eventplus_codefirst.Domains;
using Microsoft.EntityFrameworkCore;

namespace eventplus_codefirst.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE01-S15; Database = EventPlus_Tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
