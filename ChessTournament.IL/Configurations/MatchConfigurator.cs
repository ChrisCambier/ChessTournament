using ChessTournament.DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.Configurations
{
    internal class MatchConfigurator : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Match");

            builder.Property(b => b.Id).IsRequired();
            builder.HasOne(m => m.White).WithMany(p => p.MatchesAsWhite).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasOne(m => m.Black).WithMany(p => p.MatchesAsBlack).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.Property(b => b.Winner).IsRequired();
            builder.HasOne(m => m.Tournament).WithMany(p => p.Matches).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.Property(b => b.CurrentRound).IsRequired();
        }
    }
}
