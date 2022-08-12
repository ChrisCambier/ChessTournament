using ChessTournament.DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.Configurations
{
    internal class TournamentConfigurator : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.ToTable("Tournament");
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.NbPlayerMax).IsRequired();
            builder.Property(b => b.NbPlayerMin).IsRequired();
            builder.Property(b => b.Category).IsRequired();
            builder.Property(b => b.Status).IsRequired();
            builder.Property(b => b.Round).IsRequired();
            builder.Property(b => b.IsWomenOnly).IsRequired();
            builder.Property(b => b.InscriptionEndDate).IsRequired();
            builder.Property(b => b.TournamentCreationDate).IsRequired();
            builder.Property(b => b.TournamentUpdateDate).IsRequired();
            //builder.HasMany(b => b.Members).WithMany(p => p.Tournaments);
        }
    }
}