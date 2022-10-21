using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Linq;

namespace BurakWebCoreMVC.Areas.Admin.ViewComponents.Statistics
{
    public class Statistic2:ViewComponent
    {
        Context c = new();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x=>x.BlogID).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            var blogid = c.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.WriterID).Take(1).FirstOrDefault();
            ViewBag.writer = c.Writers.Where(x => x.WriterID == blogid).Select(x => x.WriterName).FirstOrDefault();
            return View();
        }
    }
}
