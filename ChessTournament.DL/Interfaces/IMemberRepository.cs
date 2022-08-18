using ChessTournament.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.DL.Interfaces
{
    public interface IMemberRepository : IRepository<int, Member>
    {
        public bool isRegistered(Func<Member, bool> predicate);
        public Member GetByIdentifiant(string identifiant);
    }

}
