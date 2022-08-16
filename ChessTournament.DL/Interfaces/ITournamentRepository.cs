using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL.Interfaces
{
    public interface ITournamentRepository : IRepository<int, Tournament>
    {
        public IEnumerable<Tournament> TenLastNotFinishedTournamentByUpdateDate();
    }
}
