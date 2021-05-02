using Bookshelf.ACore.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshelf.DataAccess.Abstract
{
    public interface IBookshelfDal : IRepositoryBase<Entity.Concrete.Bookshelf>
    {
    }
}
