using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurakWebCoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            ViewBag.Username = username;
            return View();
        }
    }
}
