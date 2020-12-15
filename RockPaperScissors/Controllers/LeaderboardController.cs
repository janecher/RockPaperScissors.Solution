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
        // GET api/leaderboard
        [HttpGet]
        public ActionResult<Object> Get()
        {
            try
            {
                return StatusCode(HttpCodes.Ok,
                                  JsonConvert.SerializeObject(Player.GetPlayersList(), Formatting.Indented));
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
