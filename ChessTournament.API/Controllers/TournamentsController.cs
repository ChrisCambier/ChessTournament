using ChessTournament.BLL.DTO;
using ChessTournament.BLL.Interfaces;
using ChessTournament.DL;
using ChessTournament.DL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChessTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private ITournamentService _tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Tournament> tournaments = new List<Tournament>();
            tournaments = _tournamentService.GetAll();
            return Ok(tournaments);            
        }

        [HttpGet("/TenLastUpdatedTournaments")]
        public IActionResult TenLastNotFinishedTournamentByUpdateDate()
        {
            IEnumerable<Tournament> tournaments = new List<Tournament>();
            tournaments = _tournamentService.TenLastNotFinishedTournamentByUpdateDate();
            return Ok(tournaments);
        }

        [HttpGet("/id")]
        public IActionResult GetById(int id)
        {
            Tournament tournament = _tournamentService.GetById(id);
            return Ok(tournament);
        }

        [Authorize("Auth")]
        [HttpPost]
        public IActionResult Insert(TournamentCreateForm tcf)
        {
            return Ok(_tournamentService.Insert(tcf));
        }

        [Authorize("Auth")]
        [HttpPatch]
        public IActionResult Update(TournamentUpdateForm tuf)
        {
            try
            {
                _tournamentService.Update(tuf);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Auth")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _tournamentService.Delete(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
