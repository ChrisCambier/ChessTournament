using ChessTournament.BLL.DTO;
using ChessTournament.BLL.Interfaces;
using ChessTournament.DL;
using ChessTournament.DL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChessTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
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

        [HttpGet("/id")]
        public IActionResult GetById(int id)
        {
            Tournament tournament = _tournamentService.GetById(id);
            return Ok(tournament);
        }

        [HttpPost]
        public IActionResult Insert(TournamentCreateForm tcf)
        {
            return Ok(_tournamentService.Insert(tcf));
        }

        [HttpPatch]
        public IActionResult Update(TournamentUpdateForm tuf)
        {
            return Ok(_tournamentService.Update(tuf));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _tournamentService.Delete(id);
            return Ok();
        }
    }
}
