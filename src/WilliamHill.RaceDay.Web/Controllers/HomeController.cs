using Microsoft.AspNetCore.Mvc;

namespace WilliamHill.RaceDay.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}