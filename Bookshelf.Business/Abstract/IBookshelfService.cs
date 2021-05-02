using Bookshelf.ACore.Abstract;
using Bookshelf.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.Business.Abstract
{
    public interface IBookshelfService
    {
        IReturnException<object> Add(Entity.Concrete.Bookshelf bookshelf);
        IReturnException<object> Update(Entity.Concrete.Bookshelf bookshelf);
        List<Entity.Concrete.Bookshelf> GetAll(int UserID);
        Entity.Concrete.Bookshelf Get(int ID,int UserID);
    }
}
