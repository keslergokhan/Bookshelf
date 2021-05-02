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
    public class BookPageService : ServiceBase<IBookPageDal,BookPage>, IBookPageService
    {
        public BookPageService(IBookPageDal bookPageDal):base(bookPageDal)
        {
                
        }

        public BookPage Get(int BookPageID)
        {
            return base.Get(p => p.BookPageID == BookPageID);
        }

        public List<BookPage> GetAll(int BookID)
        {
            return base.GetAll(b=>b.BookID == BookID);
        }
    }
}
