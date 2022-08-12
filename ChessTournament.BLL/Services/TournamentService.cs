using ChessTournament.BLL.DTO;
using ChessTournament.BLL.Interfaces;
using ChessTournament.BLL.Mappers;
using ChessTournament.DL;
using ChessTournament.DL.Enums;
using ChessTournament.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.BLL.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepo;
        public TournamentService(ITournamentRepository tournamentRepo)
        {
            _tournamentRepo = tournamentRepo;
        }
        public IEnumerable<Tournament> GetAll()
        {
            return _tournamentRepo.GetAll();
        }
        public Tournament GetById(int id)
        {
            return _tournamentRepo.GetById(id);
        }
        public int Insert(TournamentCreateForm tcf) // WARNING : Besoin d'un ID.  A FAIRE
        {
            Tournament tournament = tcf.CreateToDL();
            tournament.Status = Status.WaitingForPlayers;
            tournament.Round = 0;
            tournament.TournamentCreationDate = DateTime.Now;
            tournament.TournamentUpdateDate = DateTime.Now;

            DateTime EndInscription = tournament.TournamentCreationDate.AddDays(tournament.NbPlayerMax);
            tournament.InscriptionEndDate = EndInscription;
            return _tournamentRepo.Insert(tcf.CreateToDL());
        }

        public bool Update(TournamentUpdateForm tuf)
        {
            return _tournamentRepo.Update(tuf.UpdateToDL());
        }
        public bool Delete(int id)
        {
            return _tournamentRepo.Delete(id);
        }
    }
}
