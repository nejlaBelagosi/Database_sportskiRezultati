using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sportskiRezultati.Models;

namespace sportskiRezultati.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeamController : ControllerBase

    {
        private readonly sportskiRezultatiContext _db;
        public TeamController(sportskiRezultatiContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetTeam()
        {
            var Team = _db.Teams.ToList();
            return Ok(Team);
        }

        [HttpDelete]
        public IActionResult DeleteHomeTeam(int id)
        {
            var Team = _db.Teams.Find(id);

            if (Team == null)
            {
                return BadRequest("Korisnik nije pronajdejn");
            }

            _db.Remove(Team);
            _db.SaveChanges();

            return Ok("Team is deleted.");
        }

        [HttpPost]
        public IActionResult PostHomeTeam([FromBody] Team team)
        {
            _db.Teams.Add(new Team {
                TeamId = team.TeamId,
                TeamName = team.TeamName,
                NumberOfPlayers = team.NumberOfPlayers,
                CountryId = team.CountryId,
                LeagueId = team.LeagueId,
                MatchId = team.MatchId,
            });

            _db.SaveChanges();
            return Ok("Korisnik dodan");
        }

        [HttpPut ("{id:int}")]
        public IActionResult UpdateTeam([FromBody]Team team, int id) {
        var editTeam = _db.Teams.Find(id);
            if(team == null)
            {
                return BadRequest("Team doesn't exist.");
            }

            editTeam.TeamName= team.TeamName;
            editTeam.NumberOfPlayers= team.NumberOfPlayers;
            editTeam.CountryId= team.CountryId;
            editTeam.LeagueId= team.LeagueId;
            editTeam.MatchId= team.MatchId;

            _db.SaveChanges();
            return Ok("Team succesfully edited.");
        }

    }
}



