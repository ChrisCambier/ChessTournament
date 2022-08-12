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
    internal class MemberConfigurator : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member");
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Pseudo).IsRequired();
            builder.Property(b => b.Email).IsRequired();
            builder.Property(b => b.Password).IsRequired();
            builder.Property(b => b.Birthday).IsRequired();
            builder.Property(b => b.Gender).IsRequired();
            builder.Property(b => b.ELO).IsRequired();
            builder.Property(b => b.isAdmin).IsRequired();

            builder.HasIndex(m => m.Pseudo).IsUnique();
            builder.HasIndex(m => m.Email).IsUnique();

        }
    }
}
