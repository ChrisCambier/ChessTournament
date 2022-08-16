using ChessTournament.BLL.DTO;
using ChessTournament.BLL.Interfaces;
using ChessTournament.BLL.Mappers;
using ChessTournament.DL;
using ChessTournament.DL.Enums;
using ChessTournament.DL.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Tournament> TenLastNotFinishedTournamentByUpdateDate()
        {
            return _tournamentRepo.TenLastNotFinishedTournamentByUpdateDate();
        }
        public Tournament GetById(int id)
        {
            return _tournamentRepo.GetById(id);
        }
        public int Insert(TournamentCreateForm tcf)
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

        public void Update([FromBody]TournamentUpdateForm tuf)
        {
            //TO DO Update permise uniquement si aucun joueur inscrit.
            Tournament t = _tournamentRepo.GetById(tuf.Id);

            if(tuf.Name != null)
            {
                t.Name = tuf.Name;
            }

            if (tuf.Localisation != null)
            {
                t.Localisation = tuf.Localisation;
            }
            if (tuf.NbPlayerMax != null)
            {
                t.NbPlayerMax = (int)tuf.NbPlayerMax;
            }
            if (tuf.NbPlayerMin != null)
            {
                t.NbPlayerMin = (int)tuf.NbPlayerMin;
            }
            if (tuf.ELOMax != null)
            {
                t.ELOMax = tuf.ELOMax;
            }
            if (tuf.ELOMin != null)
            {
                t.ELOMin = tuf.ELOMin;
            }
            if (tuf.Category != null)
            {
                t.Category = (Category)tuf.Category;
            }
            if (tuf.Status != null)
            {
                t.Status = (Status)tuf.Status;
            }
            if (tuf.Round != null)
            {
                t.Round = (int)tuf.Round;
            }
            if (tuf.IsWomenOnly != null)
            {
                t.IsWomenOnly = (bool)tuf.IsWomenOnly;
            }
            if (tuf.InscriptionEndDate != null)
            {
                t.InscriptionEndDate = (DateTime)tuf.InscriptionEndDate;
            }
            

            t.TournamentUpdateDate = DateTime.Now;
            _tournamentRepo.Update(t);
            }
        public bool Delete(int id)
        {
            Tournament t = new Tournament();
            if (t.Status == Status.Started)
            {
                throw new InvalidOperationException("Tournament on Going. You can't delete this tournament.");
            }
            return _tournamentRepo.Delete(id);
        }
    }
}
