using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RockPaperScissors.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; 

namespace RockPaperScissors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        const int httpOk = 200;
        const int httpBadRequest = 400;
        const int httpInternalError = 500;

        // GET api/leaderboard
        [HttpGet]
        public ActionResult<Object> Get()
        {
            try
            {
                return StatusCode(httpOk, Json.SerializeArray(Player.GetPlayersList().ToArray(), Formatting.Indented));
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
