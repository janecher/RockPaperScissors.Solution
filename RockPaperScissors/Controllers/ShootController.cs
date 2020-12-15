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
        const int httpOk = 200;
        const int httpBadRequest = 400;
        const int httpInternalError = 500;

        // GET api/shoot
        [HttpGet]
        public ActionResult<Object> Get(string name, string play)
        {
            try
            {
                string gameResult = Player.GameResult(play, name);
                string report = $"Player {name} {gameResult} the round";
                return StatusCode(httpOk, report);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(httpBadRequest, new ErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(httpInternalError,
                                  new ErrorMessage("Internal error occured. Please contact evgeniya.chernaya@gmail.com"));
            }
        }
    }
}
