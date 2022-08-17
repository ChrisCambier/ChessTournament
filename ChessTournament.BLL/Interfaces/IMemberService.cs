using ChessTournament.BLL.DTO;
using ChessTournament.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Interfaces
{
    public interface IMemberService
    {
        IEnumerable<Member> GetAll();
        void Register(MemberRegister mr);
        public MemberLogin Login(string pseudo, string password);
    }
}
