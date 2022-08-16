using ChessTournament.DL.Enums;
using ChessTournament.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL.Models
{
    public class Member : IEntity<int>
    {
        public int Id { get; set; }
        public Guid Salt { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public int ELO { get; set; }
        public bool isAdmin { get; set; }
        public ICollection<Match> MatchesAsWhite { get; set; }
        public ICollection<Match> MatchesAsBlack { get; set; }
        public ICollection<Tournament> Tournaments { get; set; }
    }
}
