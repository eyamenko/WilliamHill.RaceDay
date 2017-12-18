using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WilliamHill.RaceDay.Contracts.Services;

namespace WilliamHill.RaceDay.Web.Controllers
{
    [Route("api/races")]
    public class RaceController : Controller
    {
        private readonly IRaceService _raceService;

        public RaceController(IRaceService raceService)
        {
            _raceService = raceService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetRaces()
        {
            try
            {
                var races = await _raceService.GetRaces();

                return Ok(races);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}