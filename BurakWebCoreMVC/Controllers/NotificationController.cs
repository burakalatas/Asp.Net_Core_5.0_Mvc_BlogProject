using Microsoft.AspNetCore.Mvc;

namespace BurakWebCoreMVC.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
