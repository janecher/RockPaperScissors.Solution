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
    public class ShootController : ControllerBase
    {
        // GET api/shoot
        [HttpGet]
        public ActionResult<Object> Get(string play, string player_name)
        {
            try
            {
                Player player = new Player(new RandomGenerator());
                string gameResult = player.PlayGame(play, player_name);
                string report = $"Player {player_name} {gameResult} the round";
                return StatusCode(HttpCodes.Ok, report);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(HttpCodes.BadRequest,
                                  new ErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(HttpCodes.InternalError,
                                  new ErrorMessage("Internal error occured. Please contact evgeniya.chernaya@gmail.com"));
            }
        }
    }
}
