using Bookshelf.ACore.Concrete;
using Bookshelf.Business.Abstract;
using Bookshelf.DataAccess.Abstract;
using Bookshelf.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Business.Concrete
{
    public class BookService : ServiceBase<IBookDal,Book>,IBookService
    {
        public BookService(IBookDal bookDal):base(bookDal)
        {

        }

        public Book Get(int BookID, int BookshelfID)
        {
            return base.Get(b=>b.BookID == BookID && b.BookshelfID == BookshelfID);
        }

        public Book Get(int BookID)
        {
            return base.Get(b => b.BookID == BookID);
        }

        public List<Book> GetAll(int BookshelfID)
        {
            return base.GetAll(u=>u.BookshelfID == BookshelfID);
        }
    }
}
