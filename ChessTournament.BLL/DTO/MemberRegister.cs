using ChessTournament.BLL.DataAnnotationsValidators;
using ChessTournament.DL.Enums;
using ChessTournament.DL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO
{
    public class MemberRegister
    {
        [Required]
        public string Pseudo { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [BeforeToday]
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }
        public int? ELO { get; set; }
    }
}
