using BurakWebCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurakWebCoreMVC.ViewComponents
{
    public class CommentList: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID=1,
                    Username="Burak"
                },
                new UserComment
                {
                    ID=2,
                    Username="Berna"
                },
                new UserComment
                {
                    ID=3,
                    Username="Ömer"
                }
            };
            return View(commentvalues);
        }
    }
}
