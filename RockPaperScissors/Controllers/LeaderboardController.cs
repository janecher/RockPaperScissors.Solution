using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Models;

namespace RockPaperScissors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        // GET api/leaderboard
        [HttpGet]
        public ActionResult<List<PlayerInfo>> Get()
        {
            try
            {
                return StatusCode(HttpCodes.Ok,
                                  Player.GetPlayersList());
            }
            catch (Exception)
            {
                return StatusCode(HttpCodes.InternalError,
                                  new ErrorMessage("Internal error occured. Please contact evgeniya.chernaya@gmail.com"));
            }
        }
    }
}
