using Bookshelf.ACore.Concrete;
using Bookshelf.Business.Abstract;
using Bookshelf.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Business.Concrete
{
    public class BookshelfService : ServiceBase<IBookshelfDal,Entity.Concrete.Bookshelf>, IBookshelfService
    {
        public BookshelfService(IBookshelfDal bookshelfDal):base(bookshelfDal)
        {
        }

        public Entity.Concrete.Bookshelf Get(int ID,int UserID)
        {
            return base.Get(b=>b.BookshelfID == ID && b.UserID == UserID);
        }

        public List<Entity.Concrete.Bookshelf> GetAll(int UserID)
        {
            return base.GetAll(b => b.UserID == UserID);
        }
    }
}
