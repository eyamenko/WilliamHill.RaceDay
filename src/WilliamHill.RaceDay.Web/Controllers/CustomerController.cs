using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WilliamHill.RaceDay.Web.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> GetCustomers()
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