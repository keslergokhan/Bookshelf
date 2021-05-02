using Bookshelf.ACore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Business.Abstract
{
    public interface IBookService
    {
        List<Entity.Concrete.Book> GetAll(int BookshelfID);
        Entity.Concrete.Book Get(int BookID,int BookshelfID);
        Entity.Concrete.Book Get(int BookID);
        IReturnException<object> Add(Entity.Concrete.Book Book);
        IReturnException<object> Delete(Entity.Concrete.Book Book);

    }
}
