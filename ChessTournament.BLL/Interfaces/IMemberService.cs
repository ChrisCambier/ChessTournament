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
        public Member GetById(int id);

        public int Insert(Member member);

        public bool Update(Member member);

        public bool Delete(int id);

        public void Register(MemberRegister mr);
    }
}
