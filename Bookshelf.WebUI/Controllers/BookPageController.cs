using Bookshelf.ACore.Abstract;
using Bookshelf.ACore.Concrete;
using Bookshelf.Business.Abstract;
using Bookshelf.WebUI.Models.BookPage;
using Bookshelf.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.WebUI.Controllers
{
    public class BookPageController : Controller
    {
        IBookService _bookService;
        IBookPageService _bookPageService;
        IBookshelfService _bookshelfService;
        IUserSessionService _userSessionService;

        public BookPageController(IBookshelfService bookshelfService, IBookService bookService, IUserSessionService userSessionService = null, IBookPageService bookPageService = null)
        {
            _bookshelfService = bookshelfService;
            _bookService = bookService;
            _userSessionService = userSessionService;
            _bookPageService = bookPageService;
        }

        [HttpGet]
        public IActionResult Add(int ID)
        {
            IReturnException<object> returnException = new ReturnException<object>();

            Entity.Concrete.Book book = _bookService.Get(ID);

            if (book != null)
            {
                Entity.Concrete.Bookshelf bookshelfControl = _bookshelfService.Get(book.BookshelfID, _userSessionService.UserGetSession().UserID);

                if (bookshelfControl != null)
                {
                    returnException = _bookPageService.Add(new Entity.Concrete.BookPage {
                        BookID = book.BookID,
                        BookPageTitle = "Başlık",
                        BookPageText = "İçerik",
                    });

                    return Redirect("/Book/Index/"+book.BookID+"/?status="+returnException.Status+"&message="+returnException.Message);

                }
            }
            return Redirect("/Bookshelf/Index?status=false&message=Kütüphaneye ulaşılamadı lütfen daha sonra tekrar deneyin !");

        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            IReturnException<object> returnException = new ReturnException<object>();

            Entity.Concrete.BookPage bookPage = _bookPageService.Get(ID);

            if (bookPage != null)
            {
                Entity.Concrete.Book book = _bookService.Get(bookPage.BookID);
                
                if (book != null)
                {
                    Entity.Concrete.Bookshelf bookshelf = _bookshelfService.Get(book.BookshelfID,_userSessionService.UserGetSession().UserID);

                    if (bookshelf != null)
                    {
                        returnException = _bookPageService.Delete(bookPage);

                        return Redirect("/Book/Index/" + book.BookID + "/?status=" + returnException.Status + "&message=" + returnException.Message);
                    }
                }            
            }
            return Redirect("/Bookshelf/Index?status=false&message=Kütüphaneye ulaşılamadı lütfen daha sonra tekrar deneyin !");
        }

        [HttpGet]
        public IActionResult Write(int ID)
        {
            Entity.Concrete.BookPage bookPage = _bookPageService.Get(ID);
            if (bookPage != null)
            {
                
                Entity.Concrete.Book book = _bookService.Get(bookPage.BookID);

                if (book != null)
                {
                    Entity.Concrete.Bookshelf bookshelf = _bookshelfService.Get(book.BookshelfID, _userSessionService.UserGetSession().UserID);

                    if (bookshelf != null)
                    {
                        var model = new BookPageModel
                        {
                            BookPage = bookPage
                        };

                        ViewBag.title = book.BookName + "/ " + bookPage.BookPageTitle;
                        return View(model);
                    }
                }
            }
            return Redirect("/Bookshelf/Index?status=false&message=Kütüphaneye ulaşılamadı lütfen daha sonra tekrar deneyin !");
        }

        [HttpPost]
        public IActionResult Write(Entity.Concrete.BookPage bookPage)
        {
            IReturnException<object> returnException = new ReturnException<object>();
            
            if (ModelState.IsValid)
            {
                Entity.Concrete.BookPage bookPageControl = _bookPageService.Get(bookPage.BookPageID);

                if (bookPageControl != null)
                {
                    Entity.Concrete.Book BookControl = _bookService.Get(bookPageControl.BookID);
                    if (BookControl != null)
                    {
                        Entity.Concrete.Bookshelf bookshelf = _bookshelfService.Get(BookControl.BookshelfID, _userSessionService.UserGetSession().UserID);

                        returnException = _bookPageService.Update(bookPage);

                        return Redirect("/BookPage/Write/" + bookPageControl.BookPageID + "/?status=" + returnException.Status + "&message=" + returnException.Message);
                      
                    }
                }
                return Redirect("/Bookshelf/Index?status=false&message=Kütüphaneye ulaşılamadı lütfen daha sonra tekrar deneyin !");
            }
            else
            {
                return View();
            }
        }

    }
}
