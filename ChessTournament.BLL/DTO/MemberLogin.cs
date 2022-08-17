using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO
{
    public class MemberLogin
    {
        [Required]
        public string Identifiant { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
