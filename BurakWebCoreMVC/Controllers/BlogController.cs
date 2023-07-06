using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurakWebCoreMVC.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new(new EfBlogRepository());
        CategoryManager cm = new(new EfCategoryRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogByID(id);
            return View(values);
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        public IActionResult BlogListByWriter()
        {
            Context c = new();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            ViewBag.Username = User.Identity.Name;
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);

        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        [HttpGet]
        public IActionResult BlogAdd()
        {
            ViewBag.Username = User.Identity.Name;
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;
            return View();
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;

            Context c = new();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                bm.Add(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.GetById(id);
            bm.Delete(blogvalue);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.GetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();

            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [Authorize(Roles = "Admin,Moderator,Writer")]
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            Context c = new();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();

            var blogvalue = bm.GetById(p.BlogID);
            p.WriterID = writerID;
            p.BlogCreateDate = DateTime.Parse(blogvalue.BlogCreateDate.ToShortDateString());
            p.BlogStatus = true;
            bm.Update(p);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
