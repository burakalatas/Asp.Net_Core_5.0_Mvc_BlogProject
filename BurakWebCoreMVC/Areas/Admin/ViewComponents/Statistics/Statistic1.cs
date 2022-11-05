using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Xml.Linq;

namespace BurakWebCoreMVC.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context c = new();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count;
            ViewBag.v2 = c.Contacts.Count();
            ViewBag.v3 = c.Comments.Count();

            string api = "2114db15079f7d377e334526df9ffd58";
            string city = "İstanbul";
            ViewBag.city = city;
            string connection = "https://api.openweathermap.org/data/2.5/weather?q="+city+"&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            var x= document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v4 = Math.Floor(decimal.Parse(x));

            return View();
        }
    }
}
