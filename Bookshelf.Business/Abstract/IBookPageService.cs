using Bookshelf.ACore.Abstract;
using Bookshelf.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Business.Abstract
{
    public interface IBookPageService
    {
        IReturnException<object> Add(BookPage bookPage);
        List<BookPage> GetAll(int BookID);
        Entity.Concrete.BookPage Get(int BookPageID);
        IReturnException<object> Delete(BookPage bookPage);
        IReturnException<object> Update(BookPage bookPage);
    }
}
