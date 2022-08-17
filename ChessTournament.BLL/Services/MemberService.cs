using ChessTournament.BLL.DTO;
using ChessTournament.BLL.Interfaces;
using ChessTournament.BLL.Mappers;
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
    public class MemberService : IMemberService
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
                throw new ValidationException("You are already registered on this website.");
            }

            using TransactionScope transactionScope = new TransactionScope();
            Member member = mr.RegisterToDL();
            member.ELO = mr.ELO ?? 1200;
            member.Salt = Guid.NewGuid();
            member.Password = Argon2.Hash(mr.Password + member.Salt);
            _memberRepo.Insert(member);
            transactionScope.Complete();
        }



        public IEnumerable<Member> GetAll()
        {
            return _memberRepo.GetAll();
        }

        public MemberLogin Login(string pseudo, string password)
        {
            // Récuperation le Hash lier au compte
            string hash = _memberRepo.GetHashByPseudo(pseudo);

            if (string.IsNullOrWhiteSpace(hash))
            {
                throw new Exception("User inexistant");
            }

            // Validation du hash avec le password
            if (Argon2.Verify(hash, password))
            {
                return _memberRepo.GetByPseudo(pseudo).ToBll();
            }
            else
            {
                throw new Exception("Mot de passe incorrect");
            }
        }
    }
}
