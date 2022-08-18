using ChessTournament.BLL.DTO;
using ChessTournament.BLL.Interfaces;
using ChessTournament.BLL.Mappers;
using ChessTournament.DL.Models;
using ChessTournament.IL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessTournament.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private IMemberService _memberService;
                private TokenManager _tokenManager;

        public MembersController(IMemberService memberService, TokenManager tokenManager)
        {
            _memberService = memberService;
            _tokenManager = tokenManager;
        }

        [HttpPost("/Register")]
        public IActionResult Register(RegisterForm mr)
        {
            try
            {
                _memberService.Register(mr);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            TokenDTO tl = new();
            
            try
            {
                tl = _memberService.Login(form);

                return Ok(_tokenManager.GenerateToken(tl));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Member> members = new List<Member>();
            members = _memberService.GetAll();
            return Ok(members);
        }
    }

}
