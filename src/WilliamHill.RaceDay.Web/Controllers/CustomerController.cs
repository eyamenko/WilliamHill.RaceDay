using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WilliamHill.RaceDay.Contracts.Services;

namespace WilliamHill.RaceDay.Web.Controllers
{
    [Route("api/customers")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customerList = await _customerService.GetCustomers();

                return Ok(customerList);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}