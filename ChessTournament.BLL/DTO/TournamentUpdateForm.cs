using ChessTournament.DL.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.DTO
{
    public class TournamentUpdateForm
    {
        [HiddenInput(DisplayValue = false)]
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Localisation { get; set; }
        [Range(2,32)]
        public int? NbPlayerMax { get; set; }
        [Range(2, 32)]
        public int? NbPlayerMin { get; set; }
        [Range(0, 3000)]
        public int? ELOMax { get; set; }
        [Range(0, 3000)]
        public int? ELOMin { get; set; }
        public Category? Category { get; set; }
        public Status? Status { get; set; }
        public int? Round { get; set; }
        public bool? IsWomenOnly { get; set; }
        public DateTime? InscriptionEndDate { get; set; }
    }
}
