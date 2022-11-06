using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace BurakWebCoreMVC.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminController : Controller
    {
        public PartialViewResult AdminNavbarPartial()
        {
            var username = User.Identity.Name;
            ViewBag.Username = username;
            return PartialView();
        }
    }
}
