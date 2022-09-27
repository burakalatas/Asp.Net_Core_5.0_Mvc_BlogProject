using BurakWebCoreMVC.Models;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BurakWebCoreMVC.Controllers
{
    [AllowAnonymous]
    public class WriterController : Controller
    {
        WriterManager wm = new(new EfWriterRepository()); 
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var writervalues = wm.GetById(1);
            return View(writervalues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            WriterValidator wl = new();
            ValidationResult results = wl.Validate(p);
            if (results.IsValid)
            {
                wm.Update(p);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new();
            if(p.WriterImage!= null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = true;
            w.WriterAbout = p.WriterAbout;

            wm.Add(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
