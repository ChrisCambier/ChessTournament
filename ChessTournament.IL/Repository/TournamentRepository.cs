using ChessTournament.DL;
using ChessTournament.DL.Interfaces;
using ChessTournament.IL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.Repository
{
    public class TournamentRepository : BaseRepository<int, Tournament>, ITournamentRepository
    {
        public TournamentRepository(TournamentDbContext context) : base(context)
        {

        }
    }
}
