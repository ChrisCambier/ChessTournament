using ChessTournament.BLL.DTO;
using ChessTournament.DL.Interfaces;
using ChessTournament.DL.Models;
using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ChessTournament.BLL.Services
{
    public class MemberService
    {
        private readonly IMemberRepository _memberRepo;

        public MemberService(IMemberRepository memberRepo)
        {
            _memberRepo = memberRepo;
        }

        public void Register(MemberRegister mr)
        {
           if (_memberRepo.isRegistered(m => m.Pseudo == mr.Pseudo || m.Email == mr.Email))
            {
                throw new ValidationException ("You are already registered on this website.");
            }

            using TransactionScope transactionScope = new TransactionScope();
            Member member = mr.RegisterToDL();
            member.ELO = mr.ELO ?? 1200;
            member.Salt = Guid.NewGuid();
            member.Password = Argon2.Hash(mr.Password+member.Salt);
            _memberRepo.Insert(member);
            transactionScope.Complete();
        }

        public IEnumerable<Member> GetAll()
        {
            return _memberRepo.GetAll();
        }
    }
}
