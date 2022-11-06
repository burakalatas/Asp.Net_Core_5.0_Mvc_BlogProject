using BurakWebCoreMVC.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BurakWebCoreMVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            ViewBag.Username = User.Identity.Name;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.username, p.password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Blog");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }



        //[HttpPost]
        //public async Task< IActionResult> Index(Writer p)
        //{
        //    Context c = new();
        //    var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

        //    if (datavalue != null)
        //    {
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,p.WriterMail)
        //        };
        //        var useridentity = new ClaimsIdentity(claims, "a");
        //        ClaimsPrincipal principal = new(useridentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index", "Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}




        //Context c = new();
        //var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

        //if(datavalue != null)
        //{
        //    HttpContext.Session.SetString("username",p.WriterMail);
        //    return RedirectToAction("Index", "Writer");
        //}
        //else
        //{
        //    return View();
        //}
    }
}
