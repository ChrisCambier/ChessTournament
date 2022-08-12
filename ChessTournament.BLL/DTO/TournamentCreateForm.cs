using ChessTournament.DL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO
{
    public class TournamentCreateForm
    {
        public string Name { get; set; }
        public string? Localisation { get; set; }
        public int NbPlayerMax { get; set; }
        public int NbPlayerMin { get; set; }
        public int? ELOMax { get; set; }
        public int? ELOMin { get; set; }
        public Category Category { get; set; }
        public bool IsWomenOnly { get; set; }
        public DateTime InscriptionEndDate { get; set; }
    }
}
