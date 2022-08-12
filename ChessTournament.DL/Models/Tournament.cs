using ChessTournament.DL.Enums;
using ChessTournament.DL.Interfaces;
using ChessTournament.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL
{
    public class Tournament : IEntity<int>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Localisation { get; set; }
        public int NbPlayerMax { get; set; }
        public int NbPlayerMin { get; set; }
        public int? ELOMax { get; set; }
        public int? ELOMin { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
        public int Round { get; set; }
        public bool IsWomenOnly { get; set; }
        public DateTime InscriptionEndDate { get; set; }
        public DateTime TournamentCreationDate { get; set; }
        public DateTime TournamentUpdateDate { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
