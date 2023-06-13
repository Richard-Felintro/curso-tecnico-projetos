using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projeto_gamer_fullstack.Models;

namespace projeto_gamer_fullstack.Infra
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = NOTE17-S14; initial catalog = gamerFullstack; User Id=sa; pwd=Senai@134; TrustServerCertificate = true");
            }
        }

        public DbSet<Jogador> Jogador {get;set;}
        public DbSet<Equipe> Equipe   {get;set;}
    }
}