using ChessTournament.DL.Enums;
using ChessTournament.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL.Models
{
    public class Match : IEntity<int>
    {
        public int Id { get; set; }
        public Member White { get; set; }
        public Member Black { get; set; }
        public Winner Winner { get; set; }
        public Tournament Tournament { get; set; }
        public int CurrentRound { get; set; }
    }
}
