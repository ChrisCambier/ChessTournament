using ChessTournament.BLL.DTO;
using ChessTournament.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Mappers
{
    public static class TournamentMapper
    {
        public static Tournament CreateToDL(this TournamentCreateForm tcf)
        {
            return new Tournament
            {
                Name = tcf.Name,
                Localisation = tcf.Localisation,
                NbPlayerMax = tcf.NbPlayerMax,
                NbPlayerMin = tcf.NbPlayerMin,
                ELOMax = tcf.ELOMax,
                ELOMin = tcf.ELOMin,
                Category = tcf.Category,
                IsWomenOnly = tcf.IsWomenOnly,
                InscriptionEndDate = tcf.InscriptionEndDate
            };
        }
        //public static Tournament UpdateToDL(this TournamentUpdateForm tuf)
        //{
        //    return new Tournament
        //    {
        //        Name = tuf.Name,
        //        Localisation = tuf.Localisation,
        //        NbPlayerMax = (int)tuf.NbPlayerMax,
        //        NbPlayerMin = (int)tuf.NbPlayerMin,
        //        ELOMax = tuf.ELOMax,
        //        ELOMin = tuf.ELOMin,
        //        Category = (Category)tuf.Category,
        //        Status = tuf.Status,
        //        Round = tuf.Round,
        //        IsWomenOnly = tuf.IsWomenOnly,
        //        InscriptionEndDate = tuf.InscriptionEndDate
        //    };
        //}

        public static TournamentCreateForm CreateToBLL(this Tournament t)
        {
            return new TournamentCreateForm
            {
                Name = t.Name,
                Localisation = t.Localisation,
                NbPlayerMax = t.NbPlayerMax,
                NbPlayerMin = t.NbPlayerMin,
                ELOMax = t.ELOMax,
                ELOMin = t.ELOMin,
                Category = t.Category,
                IsWomenOnly = t.IsWomenOnly,
                InscriptionEndDate = t.InscriptionEndDate
            };
        }
        public static TournamentUpdateForm UpdateToBLL(this Tournament t)
        {
            return new TournamentUpdateForm
            {
                Name = t.Name,
                Localisation = t.Localisation,
                NbPlayerMax = t.NbPlayerMax,
                NbPlayerMin = t.NbPlayerMin,
                ELOMax = t.ELOMax,
                ELOMin = t.ELOMin,
                Category = t.Category,
                Status = t.Status,
                Round = t.Round,
                IsWomenOnly = t.IsWomenOnly,
                InscriptionEndDate = t.InscriptionEndDate
            };
        }
    }
}