using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurakWebCoreMVC.Controllers
{
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public IActionResult AllNotification()
        {
            ViewBag.Username = User.Identity.Name;
            var values = nm.GetList();
            return View(values);
        }
    }
}
