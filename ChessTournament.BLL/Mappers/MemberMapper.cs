using ChessTournament.BLL.DTO;
using ChessTournament.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Mappers
{
    public static class MemberMapper
    {
        public static Member RegisterToDL(this RegisterForm mr)
        {
            return new Member
            {
                Pseudo = mr.Pseudo,
                Email = mr.Email,
                Birthday = mr.Birthday,
                Gender = mr.Gender,
            };
        }
        public static Member LoginToDL(this LoginForm ml)
        {
            return new Member
            {
                Pseudo = ml.Identifiant,
                Email = ml.Password,
            };
        }
    }
}