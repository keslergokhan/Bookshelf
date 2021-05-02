using Bookshelf.ACore.Abstract;
using Bookshelf.ACore.Concrete;
using Bookshelf.Business.Abstract;
using Bookshelf.WebUI.Models.Book;
using Bookshelf.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.WebUI.Controllers
{
    public class BookController : Controller
    {

        IBookshelfService _bookshelfService;
        IBookService _bookService;
        IUserSessionService _userSessionService;
        IBookPageService _bookPageService;

        public BookController(IBookshelfService bookshelfService, IUserSessionService userSessionService, IBookService bookService, IBookPageService bookPageService = null)
        {
            _bookshelfService = bookshelfService;
            _userSessionService = userSessionService;
            _bookService = bookService;
            _bookPageService = bookPageService;
        }

        [HttpGet,]
        public IActionResult Index(int ID)
        {
            Entity.Concrete.Book book = _bookService.Get(ID);
            
            if (book != null)
            {
                Entity.Concrete.Bookshelf bookshelf = _bookshelfService.Get(book.BookshelfID, _userSessionService.UserGetSession().UserID);
                if (bookshelf != null)
                {
                    var model = new BookModel
                    {
                        BookID = book.BookID,
                        BookName = book.BookName,
                        BookExplain = book.BookExplain,
                        BookshelfID = bookshelf.BookshelfID,
                        BookPages = _bookPageService.GetAll(book.BookID)
                    };

                    ViewBag.title = bookshelf.BookshelfName + " " + book.BookName;
                    ViewBag.description = book.BookExplain;
                    ViewBag.pageTitle1 = bookshelf.BookshelfName + " / " + book.BookName;

                    return View(model);
                }
            }

            return Redirect("/Bookshelf/Index?status=false&message=Kütüphaneye ulaşılamadı lütfen daha sonra tekrar deneyin !");
           

        }

        [HttpGet]
        public IActionResult Add(int ID)
        {
            Entity.Concrete.Bookshelf bookshelfControl = _bookshelfService.Get(ID,_userSessionService.UserGetSession().UserID);

            if (bookshelfControl != null)
            {
                var model = new BookAddModel
                {
                    BookshelfName = bookshelfControl.BookshelfName,
                    BookshelfID = bookshelfControl.BookshelfID
                };

                return View(model);
            }
            else
            {
                return Redirect("/Bookshelf/Index?status=false&message=Kütüphaneye ulaşılamadı lütfen daha sonra tekrar deneyin !");
            }
        }

        [HttpPost]
        public IActionResult Add(BookAddModel book)
        {
            IReturnException<object> returnException = new ReturnException<object>();

            Entity.Concrete.Bookshelf bookshelfControl = _bookshelfService.Get(book.BookshelfID,_userSessionService.UserGetSession().UserID);

            if (bookshelfControl != null )
            {
                if (ModelState.IsValid)
                {
                    Entity.Concrete.Book Book = new Entity.Concrete.Book {
                        BookName = book.BookName,
                        BookExplain = book.BookExplain,
                        BookshelfID = bookshelfControl.BookshelfID,
                    };

                    returnException = _bookService.Add(Book);
                    if (returnException.Status)
                    {
                        return Redirect("/Bookshelf/Index/?status="+returnException.Status+"&message="+returnException.Message);
                    }
                    else
                    {
                        return Redirect("/Bookshelf/Index/?status=" + returnException.Status + "&message=" + returnException.Message);
                    }
                }
                else 
                { 
                    return View(book);
                }
            }
            else
            {
                return Redirect("/Bookshelf/Index?status=false&message=Kütüphaneye ulaşılamadı lütfen daha sonra tekrar deneyin !");
            }

        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            IReturnException<object> returnException = new ReturnException<object>();

            Entity.Concrete.Book book = _bookService.Get(ID);

            if (book != null)
            {
                Entity.Concrete.Bookshelf bookshelfControl = _bookshelfService.Get(book.BookshelfID, _userSessionService.UserGetSession().UserID);

                if (bookshelfControl != null)
                {
                    returnException = _bookService.Delete(book);
                    var r = returnException.Exception;
                    return Redirect("/Bookshelf/Index/?status=" + returnException.Status + "&message=" + returnException.Message);
                }
               
            }

            return Redirect("/Bookshelf/Index?status=false&message=Kütüphaneye ulaşılamadı lütfen daha sonra tekrar deneyin !");
          
        }
    }
}
