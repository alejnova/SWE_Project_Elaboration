using Microsoft.AspNetCore.Mvc;

namespace ADHD_Software_Engineering.Controllers
{
    public class StreakController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}