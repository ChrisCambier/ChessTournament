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

        public void Register(RegisterForm mr)
        {
            if (mr.Pseudo.Contains("@"))
            {
                throw new ValidationException("Character '@' is not authorized in the Pseudo.");
            }
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

        public LoginForm Login(LoginForm ml)
        {
            // Verification si Identifiant = Pseudo ou Email existant
            if (!_memberRepo.isRegistered(m => m.Pseudo == ml.Identifiant || m.Email == ml.Identifiant))
            {
                throw new ValidationException("Your Identifiant is wrong.");
            }
            // Verification si Password = Password hashé
            Member m = new();
            m = _memberRepo.GetByIdentifiant(ml.Identifiant);
            if (Argon2.Verify(m.Password, (ml.Password + m.Salt)))
            {
                //generer le token
            }

            throw new ValidationException();
        }
    }
}
