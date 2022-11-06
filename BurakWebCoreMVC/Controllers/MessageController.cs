using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BurakWebCoreMVC.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IActionResult Inbox()
        {
            ViewBag.Username = User.Identity.Name;
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerID);
            return View(values);
        }

        public IActionResult SendBox()
        {
            ViewBag.Username = User.Identity.Name;
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = mm.GetSendBoxListByWriter(writerID);
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            ViewBag.Username = User.Identity.Name;
            var value = mm.GetById(id);

            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            ViewBag.Username = User.Identity.Name;
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            p.SenderID = writerID;
            p.ReceiverID = 2;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.Add(p);
            return RedirectToAction("Inbox");
        }
    }
}
