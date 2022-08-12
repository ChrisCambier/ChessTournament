using ChessTournament.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Interfaces
{
    internal interface IMatchService
    {
        IEnumerable<Match> Getall();
        public Match GetById(int id);


        public int Insert(Match match);

        public bool Update(Match match);

        public bool Delete(int id);
    }
}
