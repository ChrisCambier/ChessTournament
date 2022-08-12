using ChessTournament.DL;
using ChessTournament.DL.Models;
using ChessTournament.IL.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.Contexts
{
    public class TournamentDbContext : DbContext
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Member> Members { get; set; }
        public TournamentDbContext(DbContextOptions<TournamentDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TournamentConfigurator());
            modelBuilder.ApplyConfiguration(new MatchConfigurator());
            modelBuilder.ApplyConfiguration(new MemberConfigurator());
            base.OnModelCreating(modelBuilder);
        }
    }
}
