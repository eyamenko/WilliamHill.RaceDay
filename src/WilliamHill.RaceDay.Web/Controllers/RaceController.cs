using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WilliamHill.RaceDay.Web.Controllers
{
    [Route("api/races")]
    public class RaceController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> GetRaces()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}