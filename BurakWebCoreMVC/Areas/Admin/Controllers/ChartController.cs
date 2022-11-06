using BurakWebCoreMVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BurakWebCoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass 
            {
                categoryname="Teknoloji",
                categorycount=10 
            });
            list.Add(new CategoryClass
            {
                categoryname = "Yazılım",
                categorycount = 4
            });
            list.Add(new CategoryClass
            {
                categoryname = "Spor",
                categorycount = 8
            });

            return Json(new { jsonlist = list });
        }

    }
}
