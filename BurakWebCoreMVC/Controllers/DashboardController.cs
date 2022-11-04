using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurakWebCoreMVC.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context c = new();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.v1 = c.Blogs.Count();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterID == writerID).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
