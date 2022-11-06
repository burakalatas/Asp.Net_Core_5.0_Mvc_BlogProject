using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurakWebCoreMVC.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            ViewBag.Username = User.Identity.Name;
            var values = abm.GetList();
            return View(values);
        }

        public PartialViewResult SocialMediaAbout()
        { 
            return PartialView();
        }
    }
}
