using ChessTournament.DL;
using ChessTournament.DL.Interfaces;
using ChessTournament.DL.Models;
using ChessTournament.IL.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.Repository
{
    public class MemberRepository : BaseRepository<int, Member>, IMemberRepository
    {
        public MemberRepository(TournamentDbContext dbContext) : base(dbContext)
        {
        }

        public bool isRegistered(Func<Member, bool> predicate)
        {
            return _entities.Any(predicate);
        }

        public Member? GetByIdentifiant(string identifiant)
        {
            if (identifiant.Contains("@"))
            {
                return _entities.FirstOrDefault(m => m.Email == identifiant);
            }

            return _entities.FirstOrDefault(m => m.Pseudo == identifiant);
        }
    }
}
