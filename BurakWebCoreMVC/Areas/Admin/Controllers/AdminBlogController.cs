using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurakWebCoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class AdminBlogController : Controller
    {
        BlogManager blogManager = new(new EfBlogRepository());
        public IActionResult Index()
        {
            var username = User.Identity.Name;
            ViewBag.UserName = username;
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
    }
}
