using Bookshelf.WebUI.Models.Bookshelf;
using Bookshelf.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Entity.Concrete;
using Bookshelf.ACore.Concrete;
using Bookshelf.ACore.Abstract;
using Bookshelf.Business.Abstract;

namespace Bookshelf.WebUI.Controllers
{
    public class BookshelfController : Controller
    {
        IUserSessionService _userSesssionService;
        IBookshelfService _bookshelfService;
        IAccessRoleService _accessRoleService;
        IBookService _bookService;

        public BookshelfController(IUserSessionService userSessionService,IBookshelfService bookshelfService,IAccessRoleService accessRoleService,IBookService bookService)
        {
            _userSesssionService = userSessionService;
            _bookshelfService = bookshelfService;
            _accessRoleService = accessRoleService;
            _bookService = bookService;

        }

        public IActionResult Index()
        {
            User user = _userSesssionService.UserGetSession();

            if (user != null)
            {
                ViewBag.title = user != null ? user.UserName + " " + user.UserSurname : "Woheap Anasayfa";

                var Bookshelf = _bookshelfService.GetAll(_userSesssionService.UserGetSession().UserID);

                var model = new BookshelfIndexViewModel
                {
                    bookshelfBooks = Bookshelf.Select(b => new BookshelfBook { 
                        Bookshelf = b,
                        Book = _bookService.GetAll(b.BookshelfID),
                    }).ToList()
                };

                return View(model);
            }
            else
            {
                return Redirect("/User/Login");
            }
        }

        
        [HttpGet]
        public IActionResult Add()
        {

            var model = new BookshelfAddViewModel
            {
                Bookshelf = new Entity.Concrete.Bookshelf(),
                AccessRoles = _accessRoleService.GetSelectListAll()
            };

            ViewBag.title = model.Bookshelf.BookshelfName;
            ViewBag.description = model.Bookshelf.BookshelfExplain;

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Entity.Concrete.Bookshelf bookshelf)
        {
            var model = new BookshelfAddViewModel
            {
                Bookshelf = bookshelf,
                AccessRoles = _accessRoleService.GetSelectListAll()
            };

            if (ModelState.IsValid)
            {
                bookshelf.UserID = _userSesssionService.UserGetSession().UserID;

                IReturnException<object> returnException = new ReturnException<object>();
                returnException = _bookshelfService.Add(bookshelf);

                if (returnException.Status)
                {
                    return Redirect("/Bookshelf/Index?status="+returnException.Status+"&message="+returnException.Message);
                }
                else
                {
                    var e = returnException.Exception;
                    return Redirect("/Bookshelf/Add?status="+returnException.Status+"&message="+returnException.Message);
                }
            }
            else
            {
                return View(model);
            }
        }
        


        [HttpGet]
        public IActionResult Update(int ID)
        {
            var model = new BookshelfUpdateViewModel {
                Bookshelf = _bookshelfService.Get(ID, _userSesssionService.UserGetSession().UserID),
                AccessRoles = _accessRoleService.GetSelectListAll()
            };

            ViewBag.title = model.Bookshelf.BookshelfName;
            ViewBag.description = model.Bookshelf.BookshelfExplain;

            if (model.Bookshelf != null && model.Bookshelf.UserID == _userSesssionService.UserGetSession().UserID)
            {
                return View(model);
            }
            else
            {
                return Redirect("/Bookshelf/Index?status=false&message=Kütüphaneye ulaşılamadı lütfen daha sonra tekrar deneyin !");
            }

        }

        [HttpPost]
        public IActionResult Update(Entity.Concrete.Bookshelf bookshelf)
        {
            IReturnException<object> returnException = new ReturnException<object>();

            //Kütüphane kullanıcı eşleşmesi
            Entity.Concrete.Bookshelf control = _bookshelfService.Get(bookshelf.BookshelfID, _userSesssionService.UserGetSession().UserID);
            
            if (control != null)
            {   
                if (ModelState.IsValid)
                {
                    bookshelf.UserID = _userSesssionService.UserGetSession().UserID;
                    returnException = _bookshelfService.Update(bookshelf);

                    if (returnException.Status)
                    {
                        return Redirect("/Bookshelf/Update/" + bookshelf.BookshelfID + "/?status=" + returnException.Status + "&message=" + returnException.Message);
                    }
                    else
                    {
                        return Redirect("/Bookshelf/Update/" + bookshelf.BookshelfID + "/?status=" + returnException.Status + "&message=" + returnException.Message);
                    }
                }
                else
                {
                    return View(bookshelf);
                }
            }
            else
            {
                return Redirect("/Bookshelf/Index?status=false&message=Kütüphaneye ulaşılamadı lütfen daha sonra tekrar deneyin !");
            }



        }

        
    }
}
