using Bookshelf.Entity.Concrete;
using Bookshelf.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Bookshelf.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IUserSessionService _userSesssionService;

        public HomeController(IUserSessionService userSessionService)
        {
            _userSesssionService = userSessionService;
        }

        public IActionResult Index()
        {
            /*
            BookshelfContext context = new BookshelfContext();
            context.Database.EnsureCreated();
            */

            return View();
            //return Redirect("/User/Login");
        }

        
    }
}
